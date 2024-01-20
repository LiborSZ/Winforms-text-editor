using System.Text;

namespace TextEditor
{
    internal static class FileHandler
    {
        public delegate void ProgressChangedEventHandler(int progress);
        public static event ProgressChangedEventHandler? ProgressChanged;

        /// <summary>
        /// Reads asynchronously text from file and calls progressChange event for progress bar update
        /// </summary>
        /// <param name="importFileName">File to read</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public static async Task<string> ReadAsync(string importFileName, CancellationToken cancellationToken)
        {
            using (StreamReader sr = new StreamReader(importFileName))
            {
                var content = new StringBuilder();

                char[] buffer = new char[1024];
                int numRead;
                while ((numRead = await sr.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    // Kontrola, zda byla operace zrušena
                    cancellationToken.ThrowIfCancellationRequested();

                    content.Append(buffer, 0, numRead);

                    // Aktualizace progress baru
                    int progressValue = (int)((double)sr.BaseStream.Position / sr.BaseStream.Length * 100);
                    ProgressChanged?.Invoke(progressValue);

                }

                return content.ToString();
            }
        }


        /// <summary>
        /// Writes asynchronously text to file and calls progressChange event for progress bar update
        /// </summary>
        /// <param name="exportFileName">Name of exported file</param>
        /// <param name="text">Text to write</param>
        /// <returns></returns>
        public static async Task WriteAsync(string exportFileName, string text, ProgressBar progressBar, Label progressBarLabel)
        {
            using (StreamWriter sw = new StreamWriter(exportFileName))
            {

                char[] buffer = text.ToCharArray();
                int numWritten = 0;
                while (numWritten < buffer.Length)
                {
                    int numToWrite = Math.Min(1024, buffer.Length - numWritten);
                    await sw.WriteAsync(buffer, numWritten, numToWrite);
                    numWritten += numToWrite;

                    int progressValue = (int)((double)numWritten / buffer.Length * 100);
                    ProgressChanged?.Invoke(progressValue);
                }
            }
        }


    }

}
