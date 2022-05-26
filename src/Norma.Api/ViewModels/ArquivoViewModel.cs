using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Norma.Api.ViewModels
{
    public class ArquivoViewModel
    {
        public IFormFile file { get; set; }
    }
}
