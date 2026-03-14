using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Subscription.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        //Inserir
        Task AddAsync(TEntity entity);

        //Atualizar
        Task UpdateAsync(TEntity entity);

        //Excluir
        Task DeleteAsync(TEntity entity);

        //Obter por Id
        Task<TEntity?> GetByIdAsync(TKey id);

        //Listar todos
        Task<IEnumerable<TEntity>> GetAllAsync();

        //Where genérico
        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);

        //Primeiro registro baseado em uma condição
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        //Contagem
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        //Paginação
        Task<(IEnumerable<TEntity> Data, int Total)> GetPageAsync(
                int page,
                int pageSize,
                Expression<Func<TEntity, bool>>? predicate = null
            );
    }
}
