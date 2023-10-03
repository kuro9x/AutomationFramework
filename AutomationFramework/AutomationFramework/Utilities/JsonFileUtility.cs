using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectCore.Utilities
{
    public static class JsonFileUtility
    {
        public static string GetTextFromJsonFile(this string filepath)
        {
            string pathFile = filepath.GetAbsolutePath();
            return File.ReadAllText(pathFile);
        }
        public static T ReadAndParse<T>(string  filepath) where T : class
        {
            var jsonContent = GetTextFromJsonFile(filepath);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
