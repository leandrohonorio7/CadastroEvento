using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ExpositorViewModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo Nome Completo é obrigatório.")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "O Campo Empresa é obrigatório.")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "O Campo Cargo é obrigatório.")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "O Campo CPF é obrigatório.")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O Campo Telefone é obrigatório.")]
        public string Telefone { get; set; }
        public string Celular { get; set; }
        [Required(ErrorMessage = "O Campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Campo Cidade é obrigatório.")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O Campo Estado é obrigatório.")]
        public string Estado { get; set; }
    }
}