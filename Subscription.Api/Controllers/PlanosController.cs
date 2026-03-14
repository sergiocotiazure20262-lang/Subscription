using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Subscription.Domain.Entities;
using Subscription.Domain.Interfaces.Repositories;
using Subscription.Infra.Data.Contexts;

namespace Subscription.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosController (IUnitOfWork unitOfWork, ILogger<PlanosController> logger) : ControllerBase
    {
        [HttpGet("listar")]
        public async Task<IActionResult> ConsultarAsync(int page = 1, int pageSize = 10)
        {
            //Executando a paginação
            var result = await unitOfWork.PlanoRepository.GetPageAsync(page, pageSize);

            //Gerando um log de informação
            var ipOrigem = HttpContext.Connection.RemoteIpAddress?.ToString();
            logger.LogInformation(
                $"Operação de consulta de planos realizadao com sucesso em: {DateTime.Now} | IP Origem: {ipOrigem}"
                );

            //Retornar o resultado
            return Ok(new {
                page,
                pageSize,
                result.Total,
                result.Data
            });
        }
    }
}
