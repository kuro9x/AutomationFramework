using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;

namespace ProjectCore.Utilities
{
    public static class DirectoryUltility
    {
        public static string GetAbsolutePath(this string filepath)
        {
            string directoryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filepath);
            if(File.Exists(directoryPath))
            {
                return directoryPath;
            }
            return string.Empty;
        }
        
    }
}
