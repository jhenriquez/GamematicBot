using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Xunit.Sdk;

namespace GamematicBot.Core.Test.Fixtures {
    public class FromJsonArrayAttribute : DataAttribute
    {
        private readonly string FilePath;

        public FromJsonArrayAttribute(string path)
        {
            var actualPath = Path.IsPathRooted(path)
                ? path
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), path);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"FromJsonAttribute error: could not load file {actualPath}");
            }

            FilePath = actualPath;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var fileData = File.ReadAllText(FilePath);
            var data = JsonConvert.DeserializeObject<object[]>(fileData);
            return new List<object[]> { data };
        }
    }
}