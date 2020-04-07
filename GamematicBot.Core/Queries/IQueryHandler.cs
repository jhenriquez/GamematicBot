using System.Threading.Tasks;

namespace GamematicBot.Core.Queries {
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>, new()
    {
        Task<TResult> Execute(TQuery query);
    }
}