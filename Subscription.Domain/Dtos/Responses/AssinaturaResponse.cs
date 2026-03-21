using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Responses
{
    /// <summary>
    /// DTO para saída de dados de assinatura.
    /// </summary>
    public record AssinaturaResponse(
            Guid id,                    //Id da assinatura
            ClienteResponse cliente,    //Cliente que fez a assinatura
            PlanoResponse plano,        //Plano da assinatura
            DateTime dataInicio,        //Data de início da assinatura
            decimal valor,              ///Valor da assinatura
            string status               //Status da assinatura
        );
}
