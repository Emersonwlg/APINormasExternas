using System;
using System.Collections.Generic;
using System.Text;

namespace Norma.Business.Models
{
    public class Arquivo : Entity
    {
        public Guid NormaId { get; set; }

        public string Nome { get; set; }

        public string CaminhoArquivo { get; set; }

        public NormaExterna NormaExterna { get; set; }
    }
}
