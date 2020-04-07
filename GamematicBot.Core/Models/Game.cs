namespace GamematicBot.Core.Models {
    public class Game {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public double? Rating { get; set; }
    }
}