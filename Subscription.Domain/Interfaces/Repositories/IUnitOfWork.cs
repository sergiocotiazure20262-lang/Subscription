using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        //Método para 'commit' no banco de dados
        Task SaveChangesAsync();

        //Acesso ao repositório de assinaturas
        public IAssinaturaRepository AssinaturaRepository { get; }

        //Acesso ao repositório de planos
        public IPlanoRepository PlanoRepository { get; }

        //Acesso ao repositório de clientes
        public IClienteRepository ClienteRepository { get; }
    }
}
