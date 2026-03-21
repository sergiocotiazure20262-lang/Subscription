using Subscription.Domain.Dtos.Requests;
using Subscription.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Interfaces.Services
{
    /// <summary>
    /// Contrato para os serviços de dominio de cliente
    /// </summary>
    public interface IClienteService
    {
        /// <summary>
        /// Serviço para criar um novo cliente.
        /// </summary>
        Task<ClienteResponse> CriarAsync(ClienteRequest request);

        /// <summary>
        /// Serviço para obter 1 cliente pelo email
        /// </summary>
        Task<ClienteResponse> ObterAsync(string email);
    }
}
