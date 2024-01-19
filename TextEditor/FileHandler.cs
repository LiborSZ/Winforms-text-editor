using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    internal static class FileHandler
    {
        /// <summary>
        /// Reads text from file
        /// </summary>
        /// <param name="importFileName">Name of imported file</param>
        /// <returns></returns>
        public static string Read(string importFileName)
        {
            using (StreamReader sr = new StreamReader(importFileName))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// Writes text to file
        /// </summary>
        /// <param name="exportFileName">Name of exported file</param>
        /// <param name="text">Text to write</param>
        /// <returns></returns>
        public static void Write(string exportFileName, string text)
        {
            using (StreamWriter sw = new StreamWriter(exportFileName))
            {
                sw.Write(text);
            }
        }
    }
}
