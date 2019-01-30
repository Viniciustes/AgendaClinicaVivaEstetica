using AgendaClinicaVivaEstetica.Apresentacao.Models;
using AgendaClinicaVivaEstetica.Dominio.Entidades;
using AgendaClinicaVivaEstetica.Dominio.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaClinicaVivaEstetica.Apresentacao.Controllers
{
    public class MarcacaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IRepositorioMarcacao _repositorioMarcacao;

        public MarcacaoController(IMapper mapper, IRepositorioCliente repositorioCliente, IRepositorioMarcacao repositorioMarcacao)
        {
            _mapper = mapper;
            _repositorioCliente = repositorioCliente;
            _repositorioMarcacao = repositorioMarcacao;
        }

        public async Task<IActionResult> Index()
        {
            var marcacoes = await _repositorioMarcacao.BuscarComClientesTodosAsync();

            var marcacaoViewModel = _mapper.Map<IEnumerable<MarcacaoViewModel>>(marcacoes);

            return View(marcacaoViewModel);
        }

        public async Task<IActionResult> Detalhar(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcacaoViewModel = await BuscarComClientePorIdAsync((Guid)id);

            if (marcacaoViewModel == null)
            {
                return NotFound();
            }

            return View(marcacaoViewModel);
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var marcacaoViewModel = new MarcacaoViewModel()
            {
                Marcacao = await _repositorioMarcacao.BuscarPorIdAsync(id),
                Clientes = await _repositorioCliente.BuscarTodosAsync()
            };

            return View(marcacaoViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Editar(Guid id, [Bind("Marcacao,EnumTipoServico")] MarcacaoViewModel marcacaoViewModel)
        {
            if (id != marcacaoViewModel.Marcacao.IdMarcacao)
                NotFound();

            if (!ModelState.IsValid)
                return View(marcacaoViewModel);

            try
            {
                var marcacao = _mapper.Map<Marcacao>(marcacaoViewModel);

                marcacao.Validacao();

                await _repositorioMarcacao.Alterar(marcacao);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                marcacaoViewModel.Clientes = await _repositorioCliente.BuscarTodosAsync();
                return View(marcacaoViewModel);
            }
        }

        public async Task<IActionResult> Agendar()
        {
            var marcacaoViewModel = new MarcacaoViewModel()
            {
                Clientes = await _repositorioCliente.BuscarTodosAsync()
            };

            return View(marcacaoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agendar([Bind("Marcacao,EnumTipoServico")] MarcacaoViewModel marcacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                marcacaoViewModel.Clientes = await _repositorioCliente.BuscarTodosAsync();
                return View(marcacaoViewModel);
            }

            try
            {
                var marcacao = _mapper.Map<Marcacao>(marcacaoViewModel);

                marcacao.Validacao();

                await _repositorioMarcacao.SalvarAsync(marcacao);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                marcacaoViewModel.Clientes = await _repositorioCliente.BuscarTodosAsync();
                return View(marcacaoViewModel);
            }
        }

        public async Task<IActionResult> Apagar(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcacaoViewModel = await BuscarComClientePorIdAsync((Guid)id);

            if (marcacaoViewModel == null)
            {
                return NotFound();
            }

            return View(marcacaoViewModel);
        }

        [HttpPost, ActionName("Apagar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarApagar(Guid id)
        {
            await _repositorioMarcacao.ApagarPorId(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<MarcacaoViewModel> BuscarComClientePorIdAsync(Guid id)
        {
            var marcacao = await _repositorioMarcacao.BuscarComClientePorIdAsync(id);

            var marcacaoViewModel = _mapper.Map<MarcacaoViewModel>(marcacao);

            return marcacaoViewModel;
        }
    }
}