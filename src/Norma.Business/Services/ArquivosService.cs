using Norma.Business.Intefaces;
using Norma.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Norma.Business.Services
{
    public class ArquivosService : BaseService, IArquivosService
    {
        private readonly IArquivosRepository _arquivosRepository;
        private readonly IUser _user;

        public ArquivosService(IArquivosRepository arquivosRepository, 
                            INotificador notificador,  
                            IUser user) : base(notificador)
        {
            _arquivosRepository = arquivosRepository;
            _user = user;
        }

        public async Task Adicionar(Arquivo arquivos)
        {
            await _arquivosRepository.Adicionar(arquivos);
        }

        public async Task Remover(Arquivo arquivos)
        {
            await _arquivosRepository.Remover(arquivos);
        }

        public void Dispose()
        {
            _arquivosRepository?.Dispose();
        }
    }
}
