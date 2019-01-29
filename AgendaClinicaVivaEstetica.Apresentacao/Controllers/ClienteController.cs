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
    public class ClienteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioCliente _repositorioCliente;

        public ClienteController(IMapper mapper, IRepositorioCliente repositorioCliente)
        {
            _mapper = mapper;
            _repositorioCliente = repositorioCliente;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _repositorioCliente.BuscarComEnderecoTodosAsync();

            var clienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);

            return View(clienteViewModel);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("Nome,Sobrenome,Documento,Celular,Logradouro,Numero,Complemento,Cidade,Estado,CEP")] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return View(clienteViewModel);

            try
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);

                cliente.Validacao();

                await _repositorioCliente.SalvarAsync(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                return View(clienteViewModel);
            }
        }

        public async Task<IActionResult> Editar(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await BuscarComEnderecoPorId((Guid)id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Guid id, [Bind("IdCliente,Nome,Sobrenome,Documento,Celular,IdEndereco,Logradouro,Numero,Complemento,Cidade,Estado,CEP")] ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.IdCliente)
                return NotFound();

            if (!ModelState.IsValid)
                return View(clienteViewModel);

            try
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);

                await _repositorioCliente.Alterar(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                return View(clienteViewModel);
            }
        }

        public async Task<IActionResult> Detalhar(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await BuscarComEnderecoPorId((Guid)id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        public async Task<IActionResult> Apagar(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await BuscarComEnderecoPorId((Guid)id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Apagar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarApagar(Guid id)
        {
            await _repositorioCliente.ApagarPorId(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ClienteViewModel> BuscarComEnderecoPorId(Guid id)
        {
            var cliente = await _repositorioCliente.BuscarComEnderecoPorId(id);

            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);

            return clienteViewModel;
        }
    }
}