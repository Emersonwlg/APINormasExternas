using System.Collections.Generic;
using Norma.Business.Notificacoes;

namespace Norma.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}