using System;
using System.ComponentModel.DataAnnotations;

namespace UniversitarioTask.Site.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A matéria é obrigatória.")]
        [StringLength(50, ErrorMessage = "A matéria deve ter no máximo 50 caracteres.")]
        public string Materia { get; set; }

        [Required(ErrorMessage = "O nome da atividade é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string NomeAtividade { get; set; }

        [Required(ErrorMessage = "A data de entrega é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Defina o nível de dificuldade.")]
        public NivelDificuldade Dificuldade { get; set; }

        [Required(ErrorMessage = "Defina o tipo de atividade.")]
        public TipoAtividade Tipo { get; set; }

        public string FrequenciaEstudo { get; set; }

        [Range(0, 100, ErrorMessage = "O progresso deve estar entre 0 e 100.")]
        public int Progresso { get; set; }

        // Construtor vazio para o Model Binder do ASP.NET
        public Tarefa()
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now; // Default para o dia de hoje
        }

        // Construtor completo para carga inicial de dados
        public Tarefa(string materia, string nomeAtividade, DateTime data, NivelDificuldade dificuldade, TipoAtividade tipo, string frequencia, int progresso)
        {
            Id = Guid.NewGuid();
            Materia = materia;
            NomeAtividade = nomeAtividade;
            Data = data;
            Dificuldade = dificuldade;
            Tipo = tipo;
            FrequenciaEstudo = frequencia;
            Progresso = progresso;
        }
    }

    public enum NivelDificuldade
    {
        Facil = 0,
        Medio = 1,
        Dificil = 2
    }

    public enum TipoAtividade
    {
        Prova = 0,
        Entrega = 1
    }
}
