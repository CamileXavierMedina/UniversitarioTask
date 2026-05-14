using Microsoft.AspNetCore.Mvc;
using UniversitarioTask.Site.Models;
using UniversitarioTask.Site.Services;

namespace UniversitarioTask.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly FeriadoService _feriadoService;

        // Injeção do serviço de feriados via construtor
        public HomeController(FeriadoService feriadoService)
        {
            _feriadoService = feriadoService;
        }

        // A lista DEVE ser static para que os dados persistam na memória enquanto a aplicação corre
        private static List<Tarefa> listaDeTarefas = new List<Tarefa>
        {
            new Tarefa("C# e .NET", "Trabalho MVC", new DateTime(2026, 04, 21), NivelDificuldade.Dificil, TipoAtividade.Entrega, "Seg, Qua e Sex (2h)", 45),
            new Tarefa("Banco de Dados", "Prova SQL", DateTime.Now.AddDays(5), NivelDificuldade.Medio, TipoAtividade.Prova, "Ter e Qui (1h)", 15),
            new Tarefa("Algoritmos", "Lista 1", DateTime.Now.AddDays(10), NivelDificuldade.Facil, TipoAtividade.Entrega, "Sábado (3h)", 90)
        };

        public async Task<IActionResult> Index()
        {
            // 1. Procura todos os feriados de 2026 através da Brasil API
            var feriados = await _feriadoService.BuscarFeriados(2026);

            if (feriados != null)
            {
                // 2. Lógica para o Painel Superior: Filtrar apenas feriados do MÊS ATUAL
                var mesAtual = DateTime.Now.Month;
                var feriadosDoMes = feriados
                    .Where(f => DateTime.Parse(f.Date).Month == mesAtual)
                    .ToList();

                ViewBag.FeriadosDoMes = feriadosDoMes;

                // 3. Lógica de Alerta na Tabela: Verifica se cada tarefa coincide com um feriado
                foreach (var tarefa in listaDeTarefas)
                {
                    if (feriados.Any(f => DateTime.Parse(f.Date).Date == tarefa.Data.Date))
                    {
                        var nomeFeriado = feriados.First(f => DateTime.Parse(f.Date).Date == tarefa.Data.Date).Name;
                        ViewData[$"Alerta_{tarefa.Id}"] = $"Data coincide com o feriado: {nomeFeriado}!";
                    }
                }
            }

            // Retorna a lista completa (incluindo as novas atividades adicionadas)
            return View(listaDeTarefas);
        }

        // Abre a página do formulário de cadastro (GET)
        [HttpGet]
        public IActionResult Adicionar() => View();

        // Recebe os dados do formulário e guarda na lista (POST)
        [HttpPost]
        public IActionResult Adicionar(Tarefa novaTarefa)
        {
            if (novaTarefa != null)
            {
                // Garante que a tarefa tenha um identificador único (GUID)
                // Isto é essencial para o ViewData de alertas funcionar na Index
                if (novaTarefa.Id == Guid.Empty) novaTarefa.Id = Guid.NewGuid();

                // Adiciona o novo item à nossa lista estática
                listaDeTarefas.Add(novaTarefa);

                // Define a mensagem de sucesso que a Index irá exibir através do TempData
                TempData["MensagemSucesso"] = "Atividade guardada com sucesso! 🚀";

                // Redireciona para a Index para recarregar a lista e processar os feriados
                return RedirectToAction("Index");
            }

            return View(novaTarefa);
        }

        public IActionResult Detalhes(Guid id)
        {
            var tarefa = listaDeTarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) return RedirectToAction("Index");

            return View(tarefa);
        }
    }
}
