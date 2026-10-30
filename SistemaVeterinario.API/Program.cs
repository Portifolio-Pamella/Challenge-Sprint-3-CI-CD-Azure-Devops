using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaVeterinario.API.Services;
using SistemaVeterinario.Application.Extensions;
using SistemaVeterinario.Application.Service;
using SistemaVeterinario.Infrastructure.Data;
using SistemaVeterinario.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Leitura segura das chaves do JWT com fallback para testes/desenvolvimento
var jwtKey = builder.Configuration["Jwt:Key"]
             ?? builder.Configuration["Jwt__Key"]
             ?? "SuperSecretKeyJwtParaTestesComMaisDe32Caracteres123!";

var jwtIssuer = builder.Configuration["Jwt:Issuer"]
                ?? builder.Configuration["Jwt__Issuer"]
                ?? "ClyvoIssuer";

var jwtAudience = builder.Configuration["Jwt:Audience"]
                  ?? builder.Configuration["Jwt__Audience"]
                  ?? "ClyvoAudience";

// Adiciona as camadas
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// ==========================================
// REGISTRO DO AZURE SQL (ENTITY FRAMEWORK CORE)
// ==========================================
var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection")
                       ?? builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? builder.Configuration["ConnectionStrings__AzureSqlConnection"]
                       ?? builder.Configuration["ConnectionStrings__DefaultConnection"];

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// ==========================================
// Adiciona o Liveness check diretamente na API
// ==========================================
builder.Services.AddHealthChecks()
    .AddCheck("self", () => Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy(), tags: new[] { "live" });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger atualizada para suportar o Token JWT e com Título Personalizado
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clyvo API - Sistema Veterinário Challenge",
        Version = "v1",
        Description = "API RESTful desenvolvida com .NET 8 e Azure SQL (PaaS) para gestão de clínica veterinária."
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT desta forma: Bearer {seu token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Registro do TokenService para geração de tokens
builder.Services.AddSingleton<TokenService>();

// Configuração da Autenticação JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey)),

            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,

            ValidateAudience = true,
            ValidAudience = jwtAudience,

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// ==========================================
// APLICAÇÃO AUTOMÁTICA DAS MIGRAÇÕES NO AZURE SQL
// ==========================================
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate(); // Aplica todas as migrations e cria as tabelas no Azure SQL
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao aplicar as migrações na base de dados.");
    }
}

// ==========================================
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clyvo API - Sistema Veterinário");
    c.RoutePrefix = string.Empty; // Faz o Swagger abrir direto na raiz da URL!
});

// Mapeamento dos Health Checks exigidos pelo professor
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("live")
});

app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready"),
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpsRedirection();

// ORDEM OBRIGATÓRIA: UseAuthentication deve vir SEMPRE antes de UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// Obrigatório para permitir que os testes de integração acedam à aplicação
public partial class Program { }