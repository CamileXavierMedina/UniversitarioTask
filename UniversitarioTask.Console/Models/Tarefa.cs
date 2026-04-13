using System;

namespace UniversitarioTask.Console.Models
{
    
    public enum NivelDificuldade
    {
        Facil = 1,
        Medio = 2,
        Dificil = 3
    }

    public class Tarefa
    {
        
        public string Nome { get; set; }
        public DateTime DataEntrega { get; set; }
        public NivelDificuldade Dificuldade { get; set; }

        
        public Tarefa(string nome, DateTime dataEntrega, NivelDificuldade dificuldade)
        {
            Nome = nome;
            DataEntrega = dataEntrega;
            Dificuldade = dificuldade;
        }

        
        public override string ToString()
        {
            return $"[{DataEntrega:dd/MM/yyyy}] - {Nome} (Dificuldade: {Dificuldade})";
        }
    }
}