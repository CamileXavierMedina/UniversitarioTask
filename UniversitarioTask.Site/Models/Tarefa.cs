using System;

namespace UniversitarioTask.Site.Models
{
    public enum NivelDificuldade { Facil = 1, Medio = 2, Dificil = 3 }
    public enum TipoAtividade { Prova, Entrega }

    public class Tarefa
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string Materia { get; set; }
        public string NomeAtividade { get; set; }
        public DateTime Data { get; set; }
        public NivelDificuldade Dificuldade { get; set; }
        public TipoAtividade Tipo { get; set; }
        public string FrequenciaEstudo { get; set; }
        public int Progresso { get; set; }

        public Tarefa(string materia, string nomeAtividade, DateTime data, NivelDificuldade dificuldade, TipoAtividade tipo, string frequencia, int progresso)
        {
            Materia = materia;
            NomeAtividade = nomeAtividade;
            Data = data;
            Dificuldade = dificuldade;
            Tipo = tipo;
            FrequenciaEstudo = frequencia;
            Progresso = progresso;
        }
    }
}
