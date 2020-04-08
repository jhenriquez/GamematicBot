using System.Threading.Tasks;
using GamematicBot.Core.Services;

namespace GamematicBot.Core.Queries.SearchGamesByText {
    public class SearchGamesByTextQueryHandler : IQueryHandler<SearchGamesByTextQuery, SearchGamesByTextResult>
    {
        public IIGDBService IGDBService { get; private set; }

        public SearchGamesByTextQueryHandler(IIGDBService igdbService) {
            IGDBService = igdbService;
        }

        public async Task<SearchGamesByTextResult> Execute(SearchGamesByTextQuery query)
        {
            var games = await IGDBService.SearchGamesByText(query.Term);
            return new SearchGamesByTextResult { Games = games };
        }
    }
}