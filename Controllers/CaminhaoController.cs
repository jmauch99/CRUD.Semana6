using Microsoft.AspNetCore.Mvc;
using CRUDSemana6.Models;
using CRUDSemana6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDSemana6.Controllers
{
    public class CaminhaoController : Controller
    {
        private readonly ICaminhaoRepositorio _caminhaoRepository;
        public CaminhaoController(ICaminhaoRepositorio caminhaoRepository)
        {
            _caminhaoRepository = caminhaoRepository;
        }


        public IActionResult Listagem()
        {
            List<CaminhaoModel> Caminhoes = _caminhaoRepository.BuscarTodos();
            return View(Caminhoes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            CaminhaoModel caminhao = _caminhaoRepository.ListarPorId(id);
            return View(caminhao);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            CaminhaoModel caminhao = _caminhaoRepository.ListarPorId(id);
            return View(caminhao);
        }

        public IActionResult Detalhes(int id)
        {
            CaminhaoModel caminhao = _caminhaoRepository.ListarPorId(id);
            return View(caminhao);
        }
        public IActionResult Apagar(int id)
        {
            _caminhaoRepository.Apagar(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Criar(CaminhaoModel caminhao)
        {
            if(ModelState.IsValid)
            {
                DateTime Data = DateTime.Now;
                caminhao.Data = Data;
                _caminhaoRepository.Adicionar(caminhao);
                return RedirectToAction("Index", "Home");
            }
            return View(caminhao);
        }

        [HttpPost]
        public IActionResult Alterar(CaminhaoModel caminhao)
        {
            if (ModelState.IsValid)
            {
                _caminhaoRepository.Atualizar(caminhao);
                return RedirectToAction("Index", "Home");
            }
            return View("Editar", caminhao);
        }
    }
}
