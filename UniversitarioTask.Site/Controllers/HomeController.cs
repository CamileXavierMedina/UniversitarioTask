using Microsoft.AspNetCore.Mvc;
using UniversitarioTask.Site.Models;

namespace UniversitarioTask.Site.Controllers
{
    public class HomeController : Controller
    {
        
        private static List<Tarefa> listaDeTarefas = new List<Tarefa>
        {
            new Tarefa("C# e .NET", "Trabalho MVC", DateTime.Now.AddDays(2), NivelDificuldade.Dificil, TipoAtividade.Entrega, "Seg, Qua e Sex (2h)", 45),
            new Tarefa("Banco de Dados", "Prova SQL", DateTime.Now.AddDays(5), NivelDificuldade.Medio, TipoAtividade.Prova, "Ter e Qui (1h)", 15),
            new Tarefa("Algoritmos", "Lista 1", DateTime.Now.AddDays(10), NivelDificuldade.Facil, TipoAtividade.Entrega, "Sábado (3h)", 90)
        };

        public IActionResult Index() => View(listaDeTarefas);

        public IActionResult Adicionar() => View();



        public IActionResult Detalhes(Guid id)
        {
            var tarefa = listaDeTarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) return RedirectToAction("Index");
            return View(tarefa);
        }
    }
}
