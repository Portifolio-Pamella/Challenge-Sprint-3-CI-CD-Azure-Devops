# Sistema Veterinário API - Clyvo

## Integrantes
*   Felipe Ribeiro Salles de Camargo | RM565224
*   João Pedro Pereira Camilo | RM562005
*   Lucas Matsubara Reis | RM565020
*   Pamella Christiny Chaves Brito | RM565206 (RM Principal)

---

## Descrição da Solução
Esta aplicação consiste numa API RESTful desenvolvida para gerir os dados de uma clínica veterinária. O sistema permite o registo, consulta e gestão de tutores, pets e veterinários.

A solução foi arquitetada seguindo boas práticas de desenvolvimento (Clean Architecture) e, através deste repositório, implementámos um fluxo automatizado de Integração Contínua (CI) e Deploy Contínuo (CD) utilizando o Azure DevOps.

**Stack Tecnológica:**
*   **Linguagem:** C#
*   **Framework:** .NET 8 (ASP.NET Core)
*   **Mapeamento e ORM:** Entity Framework Core (EF Core)
*   **Base de Dados (Relacional PaaS):** Azure SQL Database
*   **Testes:** xUnit (Testes Unitários)
*   **DevOps e CI/CD:** Azure Pipelines (YAML)
*   **Hosting:** Azure App Service (Linux)

---

## Links do Projeto
*   **Link do Vídeo de Apresentação:** `[Adicionar link do vídeo aqui]`
*   **Link do Projeto no Azure DevOps:** `https://dev.azure.com/RM565020/Sprint%204%20%E2%80%93%20Azure%20DevOps`

---

## Arquitetura do Sistema
A imagem abaixo ilustra a arquitetura da solução e o fluxo das esteiras de CI/CD implementadas no Azure DevOps, desde o commit do desenvolvedor até o deploy no Azure App Service.

![Diagrama da Arquitetura e Fluxo CI/CD](C:\Users\pamel\Desktop\Challenge-Sprint-3-CI-CD-Azure-Devops\Scripts\img-Arquitetura\Arquitetura CI_CD do Sistema Veterinário.png)

---

## Estrutura do Repositório (Pasta Scripts)
A pasta `Scripts` contém artefactos auxiliares, documentação e scripts de infraestrutura utilizados no projeto e no processo de DevOps.

Abaixo está a descrição detalhada do conteúdo de cada subpasta:

### 1. `database/`
Contém scripts relacionados à base de dados.
*   `create_banco.sql`: Script SQL para a criação inicial ou documentação do modelo relacional no Azure SQL.

### 2. `Executaveis-Azure/`
Contém scripts de automação (Bash) para deploy de recursos na Azure via CLI.
*   `deploy-database.sh`: Script para automatizar o deploy ou gestão da base de dados na nuvem.
*   `deploy-webapp.sh`: Script para automatizar o provisionamento ou deploy da aplicação (Web App) no Azure App Service.

### 3. `img-Arquitetura/`
Contém os diagramas visuais do projeto.
*   `Arquitetura e CI_CD do Sistema Veterinário.png`: Diagrama que representa a infraestrutura da solução e o pipeline de CI/CD.

### 4. `Json-Testes-API/`
Contém ficheiros JSON utilizados para testes manuais ou automatizados dos endpoints da API.
*   `posts.json`: Massa de dados de exemplo (formato JSON) para simular requisições aos endpoints da API.

---

## Configuração e Deploy (CI/CD)

O deploy deste projeto é totalmente automatizado pelo **Azure Pipelines**. O ficheiro de configuração encontra-se na raiz do repositório com o nome `azure-pipelines.yml`.

O pipeline é dividido em dois estágios:

1.  **Build e Testes (CI):**
    *   Restaura as dependências NuGet.
    *   Compila a solução .NET 8.
    *   Executa os testes unitários (xUnit).
    *   Publica o artefacto compactado num ficheiro `.zip` limpo.
2.  **Deploy no Azure (CD):**
    *   Descarrega o artefacto gerado no estágio anterior.
    *   Faz o deploy automatizado para o Azure Web App (`clyvo-api-rm565206`) utilizando a tarefa `AzureWebApp@1` (ZIP Deploy).
    *   **Migrações Automáticas:** No arranque da aplicação (`Program.cs`), o EF Core executa o comando `dbContext.Database.Migrate()`, garantindo que as tabelas (`TB_TUTOR`, `TB_PET`, `TB_VETERINARIO`) são criadas ou atualizadas dinamicamente no **Azure SQL Database**.

Para configurar o ambiente no Azure, certifique-se de configurar a *Connection String* nas definições da aplicação do Web App com a chave:
*   `ConnectionStrings__DefaultConnection` apontando para o seu servidor Azure SQL.