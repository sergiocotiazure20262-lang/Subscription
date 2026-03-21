using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Dtos.Responses
{
    /// <summary>
    /// DTO para saída de dados de plano
    /// </summary>
    public record PlanoResponse(
            Guid id,                //Id do plano
            string nome,            //Nome do plano
            decimal valorMensal,    //Valor mensal
            string periodicidade    //Periodicidade do plano
        );
}
