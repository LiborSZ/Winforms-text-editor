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
            FileText = string.Empty;
            cts = new CancellationTokenSource();
            FileHandler.ProgressChanged += FileHandler_ProgressChanged;
            cancelButton.Enabled = false;
            StatusLabel.Visible = false;

        }

        // ProgressBar updater
        private void FileHandler_ProgressChanged(int progress)
        {
            ImportExportProgressBar.Invoke(new Action(() =>
            {
                ImportExportProgressBar.Value = progress;
                ProgressBarLabel.Text = progress.ToString() + "%";
            }));
        }

        // Statistic labels updater
        private void UpdateCounterLabels()
        {
            SentenceCounter.Text = formatter.GetSentencesCount().ToString();
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
                StatusLabel.Visible = true;
                cancelButton.Enabled = true;

                StatusLabel.ForeColor = Color.Black;
                StatusLabel.Text = "Nahrávání...";

                FileText = await FileHandler.ReadAsync(importOpenFileDialog.FileName, cts.Token);
                formatter.SetText(FileText);

                StatusLabel.ForeColor = Color.Green;
                StatusLabel.Text = "Soubor v poøádku nahrán!";
            }
            catch (OperationCanceledException)
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Operace byla zrušena.";
            }
            catch (Exception ex)
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = ex.Message;
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
                StatusLabel.Visible = true;
                cancelButton.Enabled = true;

                StatusLabel.ForeColor = Color.Black;
                StatusLabel.Text = "Ukládání...";

                await FileHandler.WriteAsync(exportSaveFileDialog.FileName, formatter.GetFormattedText(), ImportExportProgressBar, ProgressBarLabel);

                StatusLabel.ForeColor = Color.Green;
                StatusLabel.Text = "Soubor v poøádku uložen!";
            }
            catch (OperationCanceledException)
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Operace byla zrušena.";
            }
            catch (Exception ex)
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = ex.Message;
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
            cts = new CancellationTokenSource();

            try
            {
                StatusLabel.Visible = true;
                cancelButton.Enabled = true;

                StatusLabel.ForeColor = Color.Black;
                StatusLabel.Text = "Nahrávání...";

                FileText = await FileHandler.ReadAsync(importPathTextBox.Text, cts.Token);
                formatter.SetText(FileText);

                StatusLabel.ForeColor = Color.Green;
                StatusLabel.Text = "Soubor v poøádku pøekopírován!";
            }
            catch (OperationCanceledException)
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Operace byla zrušena.";
            }
            catch (Exception ex)
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = ex.Message;
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
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
                StatusLabel.Text = "Žádný proces";
            }

            ImportExportProgressBar.Value = 0;
            ProgressBarLabel.Text = "0%";
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