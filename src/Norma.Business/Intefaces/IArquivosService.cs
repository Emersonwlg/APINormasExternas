using Norma.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Norma.Business.Intefaces
{
    public interface IArquivosService : IDisposable
    {
        Task Adicionar(Arquivo arquivos);
        Task Remover(Arquivo arquivos);
    }
}
