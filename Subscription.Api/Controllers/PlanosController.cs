using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Subscription.Domain.Entities;
using Subscription.Infra.Data.Contexts;

namespace Subscription.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosController (AppDbContext context) : ControllerBase
    {
        [HttpGet("listar")]
        public async Task<IActionResult> ConsultarAsync(int page = 1, int pageSize = 10)
        {
            //Criando a query para fazer a consulta dos planos
            var query = context.Set<Plano>().AsQueryable();

            //Obtendo a quantidade total de registros da entidade no banco
            var total = await query.CountAsync();

            //Fazendo a consulta com a paginação
            var planos = await query
                            .OrderBy(p => p.Nome) //ordenar pelo nome do plano
                            .Skip((page - 1) * pageSize) //página a partir do qual iremos começar
                            .Take(pageSize) //Total de registros
                            .Select(p => new { //Selecionando os campos para retorno
                                id = p.Id,
                                nome = p.Nome.ToUpper(),
                                valorMensal = p.ValorMensal,
                                periodicidade = p.Periodicidade
                            })
                            .ToListAsync(); //Finalizar a consulta

            //Retornar o resultado
            return Ok(new {
                page,
                pageSize,
                total,
                data = planos
            });
        }
    }
}
