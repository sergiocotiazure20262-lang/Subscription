using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Requests
{
    /// <summary>
    /// DTO para entrada de dados de assinatura.
    /// </summary>
    public record AssinaturaRequest(
            Guid clienteId, //Id do cliente
            Guid planoId    //Id do plano
        );
}
