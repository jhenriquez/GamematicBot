namespace GamematicBot.Core.Queries.SearchGamesByText {
    public class SearchGamesByTextQuery : IQuery<SearchGamesByTextResult>
    {
        public string Term { get; set; }
    }
}