using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DnDCombatTracker.Core.Data
{
    public static class FileIO
    {
        public static string GetFileString(string fileName, string folder)
        {
            if (!File.Exists(string.Join("\\", folder, fileName)))
            {
                return null;
            }

            var path = Path.GetFullPath(string.Join("\\", folder, fileName));


            var str = File.ReadAllText(string.Join("\\", folder, fileName));

            return str;
        }

        public static void SaveFileString(string fileName, string folder, string content)
        {
            File.WriteAllText(string.Join("\\", folder, fileName), content);
        }
    }
}
