using System.Threading.Tasks;
using GamematicBot.Core.Models;

namespace GamematicBot.Core.Services {
    public interface IIGDBService {
        Task<Game[]> SearchGamesByText(string term);
    }
}