using Xunit;
using GamematicBot.Core.Queries;
using GamematicBot.Core.Queries.SearchGamesByText;

namespace GamematicBot.Core.Test
{
    public class SearchGamesByText
    {
        public readonly IQueryHandler<SearchGamesByTextQuery, SearchGamesByTextResult> SearchGamesQueryHandler;
        
        public SearchGamesByText(IQueryHandler<SearchGamesByTextQuery, SearchGamesByTextResult> searchGamesQueryHandler) {
            SearchGamesQueryHandler = searchGamesQueryHandler;
        }

        [Fact]
        public async void SearchGamesByText_KingdomCome_Returns_Some_Games()
        {
            var result = await SearchGamesQueryHandler.Execute(new SearchGamesByTextQuery {
                Term = "Kingdom Come"
            });
            Assert.NotEmpty(result.Games);
            Assert.Equal(7, result.Games.Length);
        }
    }
}
