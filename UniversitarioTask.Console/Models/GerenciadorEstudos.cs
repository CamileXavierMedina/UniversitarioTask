using System;

namespace UniversitarioTask.Console.Models
{
    public class GerenciadorEstudos
    {
        
        public int CalcularSessoesRecomendadas(NivelDificuldade dificuldade)
        {
            
            return dificuldade switch
            {
                NivelDificuldade.Facil => 1,  // Se for Fácil
                NivelDificuldade.Medio => 2,  // Se for Médio
                NivelDificuldade.Dificil => 3, // Se for Difícil
                _ => 0 
            };
        }
    }
}