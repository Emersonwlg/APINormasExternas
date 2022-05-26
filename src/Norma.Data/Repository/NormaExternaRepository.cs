using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Norma.Business.Intefaces;
using Norma.Business.Models;
using Microsoft.EntityFrameworkCore;
using Norma.Data.Context;

namespace Norma.Data.Repository
{
    public class NormaExternaRepository : Repository<NormaExterna>, INormaExternaRepository
    {
        public NormaExternaRepository(DataDbContext context) : base(context) { }
    }
}