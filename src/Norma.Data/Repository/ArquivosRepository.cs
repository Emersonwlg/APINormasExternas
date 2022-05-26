using Norma.Business.Intefaces;
using Norma.Business.Models;
using Norma.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Norma.Data.Repository
{
    public class ArquivosRepository : Repository<Arquivo>, IArquivosRepository
    {
        public ArquivosRepository(DataDbContext context) : base(context) { }

        public async Task<IEnumerable<Arquivo>> ObterArquivoPorIdNorma(Guid idNorma)
        {
            return await Buscar(x => x.NormaId == idNorma);
        }
    }
}
