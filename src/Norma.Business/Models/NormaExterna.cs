using System;

namespace Norma.Business.Models
{
    public class NormaExterna : Entity
    {
        public string Codigo { get; set; }

        public string Titulo { get; set; }

        public string Comite { get; set; }

        public string Idioma { get; set; }

        public int TipoNorma { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataPublicacao { get; set; }

        public DateTime DataInicioValidade { get; set; }

        public bool Ativo { get; set; }

        public Arquivo Arquivo { get; set; }
    }
}