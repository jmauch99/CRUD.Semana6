using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDSemana6.Models;
using CRUDSemana6.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSemana06.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICaminhaoRepositorio _caminhaoRepository;
        public HomeController(ICaminhaoRepositorio caminhaoRepository)
        {
            _caminhaoRepository = caminhaoRepository;
        }

        public IActionResult Index()
        {
            List<CaminhaoModel> Caminhoes = _caminhaoRepository.BuscarTodos();
            return View(Caminhoes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
