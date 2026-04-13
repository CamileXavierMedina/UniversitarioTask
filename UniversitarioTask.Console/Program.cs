using System;
using System.Collections.Generic;
using System.Linq; 
using UniversitarioTask.Console.Models;

Console.WriteLine("=== SISTEMA UNIVERSITÁRIO TASK ATIVO ===");


List<Tarefa> listaDeTarefas = new List<Tarefa>();


GerenciadorEstudos gerenciador = new GerenciadorEstudos();


listaDeTarefas.Add(new Tarefa("Trabalho de Banco de Dados", DateTime.Now.AddDays(5), NivelDificuldade.Medio));
listaDeTarefas.Add(new Tarefa("Prova de Algoritmos", DateTime.Now.AddDays(2), NivelDificuldade.Dificil));
listaDeTarefas.Add(new Tarefa("Leitura de Artigo", DateTime.Now.AddDays(10), NivelDificuldade.Facil));

var tarefasOrdenadas = listaDeTarefas.OrderBy(t => t.DataEntrega).ToList();

Console.WriteLine("\nSuas tarefas organizadas por data de entrega:");


foreach (var tarefa in tarefasOrdenadas)
{
    int sessoes = gerenciador.CalcularSessoesRecomendadas(tarefa.Dificuldade);

    
    Console.WriteLine(tarefa.ToString());
    Console.WriteLine($"   -> Recomendação: {sessoes} sessão(ões) de estudo por semana.\n");
}

Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadKey();