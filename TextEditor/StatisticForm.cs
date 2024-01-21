namespace TextEditor
{
    public partial class StatisticForm : Form
    {
        private TextFormatter formatter;
        private CancellationTokenSource cts;
        public string FileText { get; set; }

        public StatisticForm()
        {
            InitializeComponent();

            formatter = new TextFormatter();
            cts = new CancellationTokenSource();

            FileHandler.ProgressChanged += FileHandler_ProgressChanged; // progressbar event

            // label and button setting inicialization
            FileText = string.Empty;
            cancelButton.Enabled = false;
            statusLabel.Visible = false;
            saveFileButton.Enabled = false;

        }

        // ProgressBar updater
        private void FileHandler_ProgressChanged(int progress)
        {
            importExportProgressBar.Invoke(new Action(() =>
            {
                importExportProgressBar.Value = progress;
                progressBarLabel.Text = progress.ToString() + "%";
            }));
        }

        // Statistic labels updater
        private void UpdateCounterLabels()
        {
            sentenceCounter.Text = formatter.GetSentencesCount().ToString();
            rowCounter.Text = formatter.GetRowsCount().ToString();
            wordCounter.Text = formatter.GetWordsCount().ToString();
            charCounter.Text = formatter.GetCharsCount().ToString();
        }

        /// Export Import dialogs controlls

        // Calls fileHandler to read from file and sets labels
        private async void ImportOpenFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            importPathTextBox.Text = importOpenFileDialog.FileName;

            cts = new CancellationTokenSource();

            try
            {
                statusLabel.Visible = true;
                cancelButton.Enabled = true;

                statusLabel.ForeColor = Color.Black;
                statusLabel.Text = "Nahrávání...";

                FileText = await FileHandler.ReadAsync(importOpenFileDialog.FileName, cts.Token);
                formatter.SetText(FileText);
                saveFileButton.Enabled = true;
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Soubor v poøádku nahrán!";
            }
            catch (OperationCanceledException)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zrušena.";
                saveFileButton.Enabled = false;
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                saveFileButton.Enabled = false;
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

                await FileHandler.WriteAsync(exportSaveFileDialog.FileName, formatter.GetFormattedText(), importExportProgressBar, progressBarLabel);

                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Soubor v poøádku uložen!";
            }
            catch (OperationCanceledException)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zrušena.";
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
            }
        }

        /// Action buttons

        private void RemoveEmptyRowsButton_Click(object sender, EventArgs e)
        {
            formatter.RemoveEmptyRows();
            UpdateCounterLabels();
        }

        private async void CopyButton_Click(object sender, EventArgs e)
        {
            // If text exists and path to file is same as imported text path then just sets text to original, else reads text from file if file exists
            if (!string.IsNullOrEmpty(formatter.Text) && importOpenFileDialog.FileName == importPathTextBox.Text)
            {
                formatter.CopyImportedText();

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

                    FileText = await FileHandler.ReadAsync(importPathTextBox.Text, cts.Token);
                    formatter.SetText(FileText);
                    saveFileButton.Enabled = true;

                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Soubor v poøádku nahrán!";
                }
                catch (OperationCanceledException)
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = "Operace byla zrušena!";
                }
                catch (Exception ex)
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = ex.Message;
                    formatter.SetText(string.Empty);
                    saveFileButton.Enabled = false;
                }
                finally
                {
                    cts.Dispose();
                    cancelButton.Enabled = false;
                }
            }
           
            UpdateCounterLabels();

        }
        private void RemoveDiacriticButton_Click(object sender, EventArgs e)
        {
            formatter.RemoveDiacritic();
            UpdateCounterLabels();
        }

        private void RemoveSpacesPuncButton_Click(object sender, EventArgs e)
        {
            formatter.RemoveSpacesAndPunctuation();
            UpdateCounterLabels();
        }

        /// Form buttons

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

            importExportProgressBar.Value = 0;
            progressBarLabel.Text = "0%";
        }

        // Close form (and app)
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Save dialog 
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            exportSaveFileDialog.ShowDialog();
        }

        // import dialog
        private void FileBrowseButton_Click(object sender, EventArgs e)
        {
            importOpenFileDialog.ShowDialog();
        }
    }
}