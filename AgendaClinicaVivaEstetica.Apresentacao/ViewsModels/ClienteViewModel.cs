using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaClinicaVivaEstetica.Apresentacao.Models
{
    public class ClienteViewModel
    {
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "O campo nome é de preenchimento obrigatório.")]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo documento é de preenchimento obrigatório.")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O campo celular é de preenchimento obrigatório.")]
        public string Celular { get; set; }

        public Guid IdEndereco { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string CEP { get; set; }
    }
}
