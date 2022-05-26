using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Norma.Business.Models;

namespace Norma.Business.Intefaces
{
    public interface IArquivosRepository : IRepository<Arquivo>
    {
        Task<IEnumerable<Arquivo>> ObterArquivoPorIdNorma(Guid idNorma);
    }
}
