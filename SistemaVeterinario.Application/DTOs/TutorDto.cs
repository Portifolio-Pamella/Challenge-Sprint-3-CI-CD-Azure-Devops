using Swashbuckle.AspNetCore.Annotations;

namespace SistemaVeterinario.Application.DTOs;

[SwaggerSchema(Title = "TutorDto (Sprint 4 - Atualizado)", Description = "DTO responsável pelos dados do Tutor e respetivos links HATEOAS.")]
public record TutorDto(
    decimal IdTutor,
    string NomeTutor,
    string CpfTutor,
    string TelefoneTutor,
    string EmailTutor,
    string CepTutor,
    string RuaTutor,
    string NumeroTutor,
    string? ComplementoTutor,
    string BairroTutor,
    string CidadeTutor,
    string EstadoTutor,
    DateTime DataCadastroTutor,
    List<LinkDto> Links);