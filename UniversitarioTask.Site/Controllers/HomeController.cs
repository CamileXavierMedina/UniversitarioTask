using Microsoft.AspNetCore.Mvc;
using UniversitarioTask.Site.Models;
using UniversitarioTask.Site.Services;

namespace UniversitarioTask.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly FeriadoService _feriadoService;

        public HomeController(FeriadoService feriadoService)
        {
            _feriadoService = feriadoService;
        }

        // Lista estática para simular persistência em memória
        private static List<Tarefa> listaDeTarefas = new List<Tarefa>
        {
            new Tarefa("C# e .NET", "Trabalho MVC", new DateTime(2026, 04, 21), NivelDificuldade.Dificil, TipoAtividade.Entrega, "Seg, Qua e Sex (2h)", 45),
            new Tarefa("Banco de Dados", "Prova SQL", DateTime.Now.AddDays(5), NivelDificuldade.Medio, TipoAtividade.Prova, "Ter e Qui (1h)", 15),
            new Tarefa("Algoritmos", "Lista 1", DateTime.Now.AddDays(10), NivelDificuldade.Facil, TipoAtividade.Entrega, "Sábado (3h)", 90)
        };

        public async Task<IActionResult> Index()
        {
            //Procura os feriados
            var feriados = await _feriadoService.BuscarFeriados(2026);

            if (feriados != null)
            {
                //FILTRO PARA feriados do MÊS
                var mesAtual = DateTime.Now.Month;
                ViewBag.FeriadosDoMes = feriados
                    .Where(f => DateTime.Parse(f.Date).Month == mesAtual)
                    .ToList();

                //Ve se alguma tarefa coincide com feriado
                foreach (var tarefa in listaDeTarefas)
                {
                    if (feriados.Any(f => DateTime.Parse(f.Date).Date == tarefa.Data.Date))
                    {
                        var nomeFeriado = feriados.First(f => DateTime.Parse(f.Date).Date == tarefa.Data.Date).Name;
                        ViewData[$"Alerta_{tarefa.Id}"] = $" Coincide com  o feriado: {nomeFeriado}";
                    }
                }
            }

            return View(listaDeTarefas);
        }

        [HttpGet]
        public IActionResult Adicionar() => View();

        
        [HttpPost]
        public IActionResult Adicionar([FromForm] Tarefa novaTarefa)
        {
            
            if (novaTarefa == null)
            {
                return View();
            }

           
            if (novaTarefa.Id == Guid.Empty) novaTarefa.Id = Guid.NewGuid();

           
            listaDeTarefas.Add(novaTarefa);

           
            TempData["MensagemSucesso"] = "Atividade guardada com sucesso! ✅";

            // REDIRECIONA para a Index para atualizar a lista automaticamente
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(Guid id)
        {
            var tarefa = listaDeTarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) return RedirectToAction("Index");
            return View(tarefa);
        }
    }
}
