using Subscription.Domain.Dtos.Requests;
using Subscription.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Interfaces.Services
{
    /// <summary>
    /// Contrato para os serviços de dominio de assinatura
    /// </summary>
    public interface IAssinaturaService
    {
        /// <summary>
        /// Método para criar uma assinatura para um cliente em um plano
        /// </summary>
        Task<AssinaturaResponse> CriarAsync(AssinaturaRequest request);
    }
}
