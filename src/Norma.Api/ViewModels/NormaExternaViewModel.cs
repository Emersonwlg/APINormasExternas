using System;
using System.ComponentModel.DataAnnotations;

namespace Norma.Api.ViewModels
{
    public class NormaExternaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Comite { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Idioma { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TipoNorma { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataInicioValidade { get; set; }

        public bool Ativo { get; set; }
    }
}