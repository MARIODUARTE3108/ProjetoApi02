using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Models
{
    public class EnderecoPostModel
    {
        [Required(ErrorMessage = "Por favor, informe o logradouro.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Por favor, informe o número.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Por favor, informe o complemento.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Por favor, informe a cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o estado.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cep.")]
        public string Cep { get; set; }
    }
}
