using System;
using System.IO;
using Newtonsoft.Json;

namespace GamematicBot.Core.Test.Fixtures {
    public static class FileHelpers {
        public static T ReadJsonFile<T>(string path)
        {
            var actualPath = Path.IsPathRooted(path)
                ? path
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), path);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"could not load file {actualPath}");
            }

            var fileData = File.ReadAllText(actualPath);

            return JsonConvert.DeserializeObject<T>(fileData);
        }
    }
}