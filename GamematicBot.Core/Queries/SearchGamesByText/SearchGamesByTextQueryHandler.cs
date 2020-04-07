using System.Threading.Tasks;

namespace GamematicBot.Core.Queries.SearchGamesByText {
    public class SearchGamesByTextQueryHandler : IQueryHandler<SearchGamesByTextQuery, SearchGamesByTextResult>
    {
        public Task<SearchGamesByTextResult> Execute(SearchGamesByTextQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}