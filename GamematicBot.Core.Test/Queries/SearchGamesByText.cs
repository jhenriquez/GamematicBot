using Xunit;
using GamematicBot.Core.Queries;
using GamematicBot.Core.Queries.SearchGamesByText;
using GamematicBot.Core.Services;
using NSubstitute;
using GamematicBot.Core.Test.Fixtures;
using GamematicBot.Core.Models;
using System.Threading.Tasks;

namespace GamematicBot.Core.Test
{
    public class SearchGamesByText
    {
        private readonly IQueryHandler<SearchGamesByTextQuery, SearchGamesByTextResult> SearchGamesByTextQueryHandler;
        private readonly IIGDBService IGDBService;
        
        public SearchGamesByText(IQueryHandler<SearchGamesByTextQuery, SearchGamesByTextResult> searchGamesQueryHandler, IIGDBService igdbService) {
            SearchGamesByTextQueryHandler = searchGamesQueryHandler;
            IGDBService = igdbService;
        }

        [Fact]
        public async void SearchGamesByText_KingdomCome_Returns_Some_Games()
        {
            var term = "Kingdom Come";
            var fixtureValues = FileHelpers.ReadJsonFile<Game[]>("Fixtures/SearchGamesByText_KingdomeCome.json");

            IGDBService.SearchGamesByText(term).Returns(Task.FromResult(fixtureValues));

            var result = await SearchGamesByTextQueryHandler.Execute(new SearchGamesByTextQuery {
                Term = term
            });

            Assert.Equal(fixtureValues, result.Games);
            Assert.NotEmpty(result.Games);
            Assert.Equal(7, result.Games.Length);
        }
    }
}
