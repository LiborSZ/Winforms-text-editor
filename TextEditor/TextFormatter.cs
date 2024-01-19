using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    internal class TextFormatter
    {
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
            Text = "";
            FormattedText = "";
        }

        /// <summary>
        /// Method calls read from file, if fails returns error message
        /// </summary>
        /// <param name="fileName">Read file name</param>
        /// <param name="errorMessage">Fail reason</param>
        /// <returns></returns>
        public bool ReadTextFile(string fileName, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                Text = FileHandler.Read(fileName);
                FormattedText = Text;
                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                FormattedText = string.Empty;
                return false;
            }
            
        }

        /// <summary>
        /// Method calls write to file, if fails returns error message
        /// </summary>
        /// <param name="fileName">Write file name</param>
        /// <param name="errorMessage">Fail reason</param>
        /// <returns></returns>
        public bool WriteTextFile(string fileName, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                FileHandler.Write(fileName, FormattedText);
                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
                
            }
            
        }
    }        
}
