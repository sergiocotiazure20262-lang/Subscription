using Subscription.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Events
{
    /// <summary>
    /// DTO com o modelo de dados do evento de assinatura criada
    /// </summary>
    public record AssinaturaCriadaEvent(
            Guid id, //Id do evento
            DateTime dataHora, //Data e hora do evento
            AssinaturaResponse assinatura //Dados da assinatura
        );
}
