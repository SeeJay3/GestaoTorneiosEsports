using GestaoTorneiosEsports.Data;
using GestaoTorneiosEsports.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTorneiosEsports.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly AppDbContext _context;

        public ConsultasController(AppDbContext context)
        {
            _context = context;
        }

        // Página inicial de consultas
        public IActionResult Index()
        {
            return View();
        }

        // Consulta 1: Equipes com seus respectivos torneios (relacionamento entre as duas classes)
        public async Task<IActionResult> EquipesComTorneios()
        {
            var equipesComTorneios = await _context.Equipes
                .Include(e => e.Torneio)
                .Where(e => e.Torneio != null)
                .Select(e => new EquipeTorneioViewModel
                {
                    EquipeId = e.EquipeId,
                    EquipeNome = e.Nome,
                    EquipeTag = e.Tag,
                    TorneioNome = e.Torneio.Nome,
                    Jogo = e.Torneio.Jogo,
                    DataInicio = e.Torneio.DataInicio,
                    Pontuacao = e.Pontuacao
                })
                .ToListAsync();

            return View(equipesComTorneios);


        }

        // Consulta 2: Estatísticas dos torneios (usando funções de grupo)
        public async Task<IActionResult> EstatisticasTorneios()
        {
            var estatisticas = await _context.Torneios
                .Select(t => new EstatisticaTorneioViewModel
                {
                    TorneioId = t.TorneioId,
                    TorneioNome = t.Nome,
                    Jogo = t.Jogo,
                    QuantidadeEquipes = t.Equipes.Count(),
                    PontuacaoMedia = t.Equipes.Any() ? t.Equipes.Average(e => e.Pontuacao) : 0,
                    PontuacaoMaxima = t.Equipes.Any() ? t.Equipes.Max(e => e.Pontuacao) : 0,
                    PontuacaoMinima = t.Equipes.Any() ? t.Equipes.Min(e => e.Pontuacao) : 0,
                    PremioTotal = t.PremioTotal
                })
                .ToListAsync();

            return View(estatisticas);
        }

        // Consulta 3: Torneios filtrados por jogo e com critérios específicos (where e having)
        public async Task<IActionResult> TorneiosFiltrados(string jogo, int minEquipes = 2, int pontuacaoMinima = 70)
        {
            ViewBag.Jogo = jogo;
            ViewBag.MinEquipes = minEquipes;
            ViewBag.PontuacaoMinima = pontuacaoMinima;

            // Lista de jogos para o filtro
            ViewBag.Jogos = await _context.Torneios
                .Select(t => t.Jogo)
                .Distinct()
                .ToListAsync();

            var query = _context.Torneios.AsQueryable();

            // Aplicar filtro Where se um jogo foi especificado
            if (!string.IsNullOrEmpty(jogo))
            {
                query = query.Where(t => t.Jogo == jogo);
            }

            // Projetar os resultados com as informações necessárias
            var projecao = query.Select(t => new TorneioFiltradoViewModel
            {
                TorneioId = t.TorneioId,
                TorneioNome = t.Nome,
                Jogo = t.Jogo,
                QuantidadeEquipes = t.Equipes.Count(),
                PontuacaoMedia = t.Equipes.Any() ? t.Equipes.Average(e => e.Pontuacao) : 0,
                DataInicio = t.DataInicio,
                DataFim = t.DataFim,
                PremioTotal = t.PremioTotal
            });

            // Aplicar filtro Having
            var resultado = await projecao
                .Where(t => t.QuantidadeEquipes >= minEquipes && t.PontuacaoMedia >= pontuacaoMinima)
                .ToListAsync();

            return View(resultado);
        }
    }
}