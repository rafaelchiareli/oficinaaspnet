using ClinicaASPNet.Models;
using ClinicaASPNet.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.IO.Pipelines;
using System.Reflection.Metadata.Ecma335;

namespace ClinicaASPNet.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteRepository _repository;

        public PacientesController(IPacienteRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index(string? nome)
        {
            ViewBag.NomePesquisado = nome;
            var pacientes = _repository.Listar();
            return View(pacientes);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var paciente = _repository.BuscarPorId(id);
            if (paciente is null) return NotFound();
            return View(paciente);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {
            if (_repository.CpfJaCadastrado(paciente.Cpf))
            {
                ModelState.AddModelError(nameof(paciente.Cpf), "Ja existe um paciente" +
                    "cadastrado com esse CPF");
            }
            if (ModelState.IsValid == false)
            {
                return View(paciente);
            }
            _repository.Adicionar(paciente);
            TempData["MensagemSucesso"] = "Paciente cadastrado com sucesso";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var paciente = _repository.BuscarPorId(id);
            if (paciente is null) return NotFound();
            return View(paciente);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Paciente paciente, int id)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }
            if (_repository.CpfJaCadastrado(paciente.Cpf))
            {
                ModelState.AddModelError(nameof(paciente.Cpf), "Ja existe um paciente" +
                    "cadastrado com esse CPF");
            }
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }
            if (!_repository.Atualizar(paciente))
            {
                return NotFound();
            }
              TempData["MensagemSucesso"] = "Paciente cadastrado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var paciente = _repository.BuscarPorId(id);
            if (paciente is null) return NotFound();
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(int id)
        {
            if (!_repository.Excluir(id)) return NotFound();
            TempData["MensagemSucesso"] = "Paciente excluído com sucesso";
            return RedirectToAction("Index");

         }
    }
}
