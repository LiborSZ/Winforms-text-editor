namespace TextEditor
{
    public partial class StatisticForm : Form
    {
        private TextFormatter formatter;
        private CancellationTokenSource? cts;
        public string FileText { get; set; }

        public StatisticForm()
        {
            InitializeComponent();

            formatter = new TextFormatter();
            cts = null;

            // Events bounds to progress bar
            FileHandler.ProgressChanged += ProgressBar_ProgressChanged; 
            TextFormatter.ProgressChanged += ProgressBar_ProgressChanged;

            // labels and buttons setting inicialization
            SetActionButtonsState(false);
            saveFileButton.Enabled = false;
            FileText = string.Empty;
            cancelButton.Enabled = false;
            statusLabel.Visible = false;
        }

        //// Private methods ////

        /// <summary>
        /// Progress bar update callback
        /// </summary>
        /// <param name="progress"></param>
        private void ProgressBar_ProgressChanged(int progress)
        {
            importExportProgressBar.Invoke(new Action(() =>
            {
                importExportProgressBar.Value = progress;
                progressBarLabel.Text = progress.ToString() + "%";
            }));
        }

        /// <summary>
        /// Updates statistic labels
        /// </summary>
        private void UpdateCounterLabels()
        {
            sentenceCounter.Text = formatter.GetSentencesCount().ToString();
            rowCounter.Text = formatter.GetRowsCount().ToString();
            wordCounter.Text = formatter.GetWordsCount().ToString();
            charCounter.Text = formatter.GetCharsCount().ToString();
        }

        /// <summary>
        /// Sets action buttons to disabled or enabled state
        /// </summary>
        /// <param name="enabled"></param>
        private void SetActionButtonsState(bool enabled)
        {
            removeDiacriticButton.Enabled = enabled;
            removeEmptyRowsButton.Enabled = enabled;
            removeSpacesPuncButton.Enabled = enabled;
        }

        /// <summary>
        /// Resets progress bar and % label to 0
        /// </summary>
        private void ResetProgressBarAndLabel()
        {
            importExportProgressBar.Value = 0;
            progressBarLabel.Text = "0%";
        }

        //// Export Import dialogs controlls ////

        // Calls fileHandler to read from file and sets labels and buttons
        private async void ImportOpenFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            importPathTextBox.Text = OpenFileDialog.FileName;

            cts = new CancellationTokenSource();

            try
            {
                statusLabel.Visible = true;
                cancelButton.Enabled = true;

                statusLabel.ForeColor = Color.Black;
                statusLabel.Text = "Nahrávání...";

                string fileName = OpenFileDialog.FileName;

                string extension = Path.GetExtension(fileName);

                if (!File.Exists(fileName) || string.IsNullOrEmpty(fileName))
                {
                    throw new Exception("Neplatná cesta k souboru!");
                }
                else if (extension != ".txt")
                {
                    throw new Exception("Nepodporovaný formát! Program podporuje pouze textový soubor.");
                }

                FileText = await FileHandler.ReadAsync(fileName, cts.Token);
                formatter.SetText(FileText);
                SetActionButtonsState(true);
                saveFileButton.Enabled = true;
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Soubor v poøádku nahrán!";
            }
            catch (OperationCanceledException)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zrušena.";
                saveFileButton.Enabled = false;
                SetActionButtonsState(false);
                ResetProgressBarAndLabel();
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                saveFileButton.Enabled = false;
                SetActionButtonsState(false);
                ResetProgressBarAndLabel();
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
            }

            UpdateCounterLabels();
        }

        // Calls fileHandler to write to file and sets labels
        private async void ExportSaveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cts = new CancellationTokenSource();

            try
            {
                statusLabel.Visible = true;
                cancelButton.Enabled = true;

                statusLabel.ForeColor = Color.Black;
                statusLabel.Text = "Ukládání...";

                string fileName = SaveFileDialog.FileName;

                string extension = Path.GetExtension(fileName);

                if (extension != ".txt")
                {
                    throw new Exception("Nepodporovaný formát! Program podporuje pouze textový soubor.");
                }

                await FileHandler.WriteAsync(SaveFileDialog.FileName, formatter.GetFormattedText(), importExportProgressBar, progressBarLabel);

                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Soubor v poøádku uložen!";
                ResetProgressBarAndLabel();
            }
            catch (OperationCanceledException)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zrušena.";
                ResetProgressBarAndLabel();
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
                SetActionButtonsState(true);
            }
        }

        //// Action buttons ////

        // Calls removeEmptyRows asynchronously and sets / update labels and buttons in try-catch
        private async void RemoveEmptyRowsButton_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            try
            {
                statusLabel.Visible = true;
                cancelButton.Enabled = true;

                statusLabel.ForeColor = Color.Black;
                statusLabel.Text = "Odstraòuji prázdné øádky...";
                await Task.Run(() => formatter.RemoveEmptyRows(cts.Token));
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Prázdné øádky odstranìny!";

            }
            catch (OperationCanceledException)
            {

                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zrušena!";
                ResetProgressBarAndLabel();
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                ResetProgressBarAndLabel();
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
                UpdateCounterLabels();
                SetActionButtonsState(true);

            }
        }

        //Update text to original text from loaded file or asynchronously reads and sets / update labels and buttons in try-catch
        private async void CopyButton_Click(object sender, EventArgs e)
        {
            // If text exists and path to file is same as imported text path then just sets text to original, else reads text from file if file exists
            if (!string.IsNullOrEmpty(formatter.Text) && OpenFileDialog.FileName == importPathTextBox.Text)
            {
                formatter.CopyImportedText();
                importExportProgressBar.Value = 100;
                progressBarLabel.Text = "100%";
                SetActionButtonsState(true);
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Soubor pøekopírován!";
            }
            else
            {
                cts = new CancellationTokenSource();

                try
                {
                    statusLabel.Visible = true;
                    cancelButton.Enabled = true;

                    statusLabel.ForeColor = Color.Black;
                    statusLabel.Text = "Nahrávání...";

                    string filePath = importPathTextBox.Text;

                    string extension = Path.GetExtension(filePath);

                    if (!File.Exists(filePath) || string.IsNullOrEmpty(filePath))
                    {
                        throw new Exception("Neplatná cesta k souboru!");
                    }
                    else if (extension != ".txt")
                    {
                        throw new Exception("Nepodporovaný formát! Program podporuje pouze textový soubor.");
                    }


                    FileText = await FileHandler.ReadAsync(filePath, cts.Token);
                    formatter.SetText(FileText);
                    SetActionButtonsState(true);
                    saveFileButton.Enabled = true;

                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Soubor v poøádku nahrán!";
                }
                catch (OperationCanceledException)
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = "Operace byla zrušena!";
                    SetActionButtonsState(false);
                    ResetProgressBarAndLabel();
                }
                catch (Exception ex)
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = ex.Message;
                    formatter.SetText(string.Empty);
                    saveFileButton.Enabled = false;
                    SetActionButtonsState(false);
                    ResetProgressBarAndLabel();
                }
                finally
                {
                    cts.Dispose();
                    cancelButton.Enabled = false;
                }
            }
           
            UpdateCounterLabels();

        }

        // Calls RemoveDiacritic asynchronously and sets / update labels and buttons in try-catch
        private async void RemoveDiacriticButton_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            try
            {
                statusLabel.Visible = true;
                cancelButton.Enabled = true;

                statusLabel.ForeColor = Color.Black;
                statusLabel.Text = "Odstraòuji diakritiku...";
                await Task.Run(() => formatter.RemoveDiacritic(cts.Token));
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Diakritika odstranìna!";

            }
            catch (OperationCanceledException)
            {

                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zrušena!";
                ResetProgressBarAndLabel();
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                ResetProgressBarAndLabel();
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
                SetActionButtonsState(true);
            }
            UpdateCounterLabels();
        }

        // Calls RemoveSpacesAndPunctuation asynchronously and sets / update labels and buttons in try-catch
        private async void RemoveSpacesPuncButton_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            try
            {
                statusLabel.Visible = true;
                cancelButton.Enabled = true;

                statusLabel.ForeColor = Color.Black;
                statusLabel.Text = "Odstraòuji mezery a interpunkci, implementuji CamelCase notaci na slova...";
                await Task.Run(() => formatter.RemoveSpacesAndPunctuation(cts.Token));
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Mezery a interpunkce odstranìna a slova pøetransformována na CamelCase!";

            }
            catch (OperationCanceledException)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zrušena!";
                ResetProgressBarAndLabel();
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                ResetProgressBarAndLabel();
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
                SetActionButtonsState(true);
            }
            UpdateCounterLabels();
        }

        //// Form controll buttons ////

        // Cancels actual process and sets progress bar to 0
        private void CancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                cts?.Cancel();
            }
            catch
            {
                statusLabel.Text = "Žádný proces";
            }
        }

        // Removing events and close form
        private void CloseButton_Click(object sender, EventArgs e)
        {
            FileHandler.ProgressChanged -= ProgressBar_ProgressChanged;
            TextFormatter.ProgressChanged -= ProgressBar_ProgressChanged;
            Close();
        }

        // Export dialog 
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.ShowDialog();
        }

        // import dialog
        private void FileBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
        }
    }
}