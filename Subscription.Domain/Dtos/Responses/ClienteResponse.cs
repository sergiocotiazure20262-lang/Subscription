using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Responses
{
    /// <summary>
    /// DTO para saída de dados de cliente
    /// </summary>
    public record ClienteResponse(
            Guid id,                //id do cliente
            string nome,            //nome do cliente
            string email,           //email do cliente
            DateTime dataCadastro,  //data e hora de cadastro
            string status           //status do cliente
        );
}
