using System;
using System.Threading.Tasks;
using Norma.Business.Models;

namespace Norma.Business.Intefaces
{
    public interface INormaExternaService : IDisposable
    {
        Task Adicionar(NormaExterna normaExterna);
        Task Atualizar(NormaExterna NormaExterna);
        Task Remover(NormaExterna NormaExterna);
    }
}