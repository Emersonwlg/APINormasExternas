using System;
using System.Threading.Tasks;
using Norma.Business.Intefaces;
using Norma.Business.Models;
using Norma.Business.Models.Validations;

namespace Norma.Business.Services
{
    public class NormaExternaService : BaseService, INormaExternaService
    {
        private readonly INormaExternaRepository _normaExternaRepository;
        private readonly IUser _user;

        public NormaExternaService(INormaExternaRepository normaExternaRepository,
                              INotificador notificador, 
                              IUser user) : base(notificador)
        {
            _normaExternaRepository = normaExternaRepository;
            _user = user;
        }

        public async Task Adicionar(NormaExterna normaExterna)
        {
            if (!ExecutarValidacao(new NormaExternaValidation(), normaExterna)) return;

            await _normaExternaRepository.Adicionar(normaExterna);
        }

        public async Task Atualizar(NormaExterna normaExterna)
        {
            if (!ExecutarValidacao(new NormaExternaValidation(), normaExterna)) return;

            await _normaExternaRepository.Atualizar(normaExterna);
        }

        public async Task Remover(NormaExterna NormaExterna)
        {
            await _normaExternaRepository.Remover(NormaExterna);
        }

        public void Dispose()
        {
            _normaExternaRepository?.Dispose();
        }
    }
}