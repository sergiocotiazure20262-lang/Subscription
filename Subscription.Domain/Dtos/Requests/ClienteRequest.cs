using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Requests
{
    /// <summary>
    /// DTO para entrada de dados de cliente.
    /// </summary>
    public record ClienteRequest(
            string nome,    //Nome do cliente
            string email    //Email do cliente
        );
}
