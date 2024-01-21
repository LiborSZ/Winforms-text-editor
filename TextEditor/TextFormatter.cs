using System.Globalization;
using System.Text;

namespace TextEditor
{
    internal class TextFormatter
    {
        public delegate void ProgressChangedEventHandler(int progress);
        public static event ProgressChangedEventHandler? ProgressChanged;
        /// <summary>
        /// Text value from readed file
        /// </summary>
        public string Text { get; private set; }
        /// <summary>
        /// Text value after text is formatted
        /// </summary>
        public string FormattedText { get; private set; }

        /// <summary>
        /// Constructor - inicialize file handler and text properties
        /// </summary>
        public TextFormatter()
        {
            Text = string.Empty;
            FormattedText = string.Empty;
        }

        /// <summary>
        /// Removes all empty rows from file text
        /// </summary>
        public void RemoveEmptyRows(CancellationToken cancellationToken)
        {
            // split string by lines
            string[] lines = FormattedText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sbReturn = new StringBuilder(FormattedText.Length);
            int totalLength = lines.Length;
            int currentLength = 0;
            // append lines back
            foreach (string line in lines)
            {
                sbReturn.AppendLine(line);

                currentLength++;
                // Aktualizace progress baru
                if (currentLength % 1000 == 0)
                {
                    int progressValue = Math.Min(100, (int)((double)currentLength / totalLength * 100));
                    ProgressChanged?.Invoke(progressValue);
                }
            }

            // loop is done, progressbar should be on 100%
            ProgressChanged?.Invoke(100);
            FormattedText = sbReturn.ToString();
        }

        /// <summary>
        /// Removes diacritic from text
        /// </summary>
        public void RemoveDiacritic(CancellationToken cancellationToken)
        {
            StringBuilder sbReturn = new StringBuilder();
            char[] arrayText = FormattedText.Normalize(NormalizationForm.FormD).ToCharArray();
            int totalLength = arrayText.Length;
            int currentLength = 0;
            foreach (char letter in arrayText)
            {
                // Kontrola, zda byla operace zrušena
                cancellationToken.ThrowIfCancellationRequested();
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                {
                    sbReturn.Append(letter);
                }

                currentLength++;
                // Aktualizace progress baru
                if (currentLength % 1000 == 0)
                {
                    int progressValue = Math.Min(100, (int)((double)currentLength / totalLength * 100));
                    ProgressChanged?.Invoke(progressValue);
                }

            }
            // loop is done, progressbar should be on 100%
            ProgressChanged?.Invoke(100);

            FormattedText = sbReturn.ToString();

        }

        /// <summary>
        /// Removes all empty spaces, punction and transform text into CamelCase notation
        /// </summary>
        public void RemoveSpacesAndPunctuation(CancellationToken cancellationToken)
        {

            if (!string.IsNullOrEmpty(Text))
            {
                // Removes punctuation and split text by space
                string[] splittedText = new string(FormattedText.Where(c => !char.IsPunctuation(c)).ToArray()).Split(new string[] { " " }, StringSplitOptions.None);
                int totalLength = splittedText.Length;
                int currentLength = 0;
                var sb = new StringBuilder();

                // Iterrates splitted text and append with first char of every word upper
                for (int i = 0; i < splittedText.Length; i++)
                {
                    if (!string.IsNullOrEmpty(splittedText[i]))
                    {
                        sb.Append(splittedText[i][0].ToString().ToUpper() + splittedText[i].Substring(1));
                    }
                    else
                    {
                        sb.Append("\n");
                    }
                    currentLength++;
                    // Aktualizace progress baru
                    if (currentLength % 1000 == 0)
                    {
                        int progressValue = Math.Min(100, (int)((double)currentLength / totalLength * 100));
                        ProgressChanged?.Invoke(progressValue);
                    }
                }
                // loop is done, progressbar should be on 100%
                ProgressChanged?.Invoke(100);
                FormattedText = sb.ToString();
            }
        }

        /// <summary>
        /// Counts all words in text from file
        /// </summary>
        /// <returns></returns>
        public int GetWordsCount()
        {
            return FormattedText.Split(new char[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Counts all rows in text from file
        /// </summary>
        /// <returns></returns>
        public int GetRowsCount()
        {
            return string.IsNullOrEmpty(FormattedText) ? 0 : FormattedText.Split(Environment.NewLine).Length;
        }

        /// <summary>
        /// Counts all sentences in text from file
        /// </summary>
        /// <returns></returns>
        public int GetSentencesCount()
        {
            return FormattedText.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Counts all chars in text from file
        /// </summary>
        /// <returns></returns>
        public int GetCharsCount()
        {
            var charsLenght = FormattedText.Select(s => s).ToList().Count;
            return charsLenght;
        }

        /// <summary>
        /// Sets properties Text and FormattedText to imported file text
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            Text = text;
            FormattedText = text;
        }

        /// <summary>
        /// Return formatted text
        /// </summary>
        /// <returns></returns>
        public string GetFormattedText()
        {
            return FormattedText;
        }

        /// <summary>
        /// Copies original text
        /// </summary>
        public void CopyImportedText()
        {
            FormattedText = Text;
        }

    }
}
