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
                statusLabel.Text = "Nahr�v�n�...";

                FileText = await FileHandler.ReadAsync(OpenFileDialog.FileName, cts.Token);
                formatter.SetText(FileText);
                SetActionButtonsState(true);
                saveFileButton.Enabled = true;
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Soubor v po��dku nahr�n!";
            }
            catch (OperationCanceledException)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zru�ena.";
                saveFileButton.Enabled = false;
                SetActionButtonsState(false);
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                saveFileButton.Enabled = false;
                SetActionButtonsState(false);
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
                statusLabel.Text = "Ukl�d�n�...";

                await FileHandler.WriteAsync(SaveFileDialog.FileName, formatter.GetFormattedText(), importExportProgressBar, progressBarLabel);

                SetActionButtonsState(true);
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Soubor v po��dku ulo�en!";
            }
            catch (OperationCanceledException)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zru�ena.";
                SetActionButtonsState(false);
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                SetActionButtonsState(false);
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
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
                statusLabel.Text = "Odstra�uji pr�zdn� ��dky...";
                await Task.Run(() => formatter.RemoveEmptyRows(cts.Token));
                SetActionButtonsState(true);
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Pr�zdn� ��dky odstran�ny!";

            }
            catch (OperationCanceledException)
            {

                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zru�ena!";
                SetActionButtonsState(false);
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                SetActionButtonsState(false);
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
                UpdateCounterLabels();

            }
        }

        //Update text to original text from loaded file or asynchronously reads and sets / update labels and buttons in try-catch
        private async void CopyButton_Click(object sender, EventArgs e)
        {
            // If text exists and path to file is same as imported text path then just sets text to original, else reads text from file if file exists
            if (!string.IsNullOrEmpty(formatter.Text) && OpenFileDialog.FileName == importPathTextBox.Text)
            {
                formatter.CopyImportedText();

                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Soubor p�ekop�rov�n!";
            }
            else
            {
                cts = new CancellationTokenSource();

                try
                {
                    statusLabel.Visible = true;
                    cancelButton.Enabled = true;

                    statusLabel.ForeColor = Color.Black;
                    statusLabel.Text = "Nahr�v�n�...";

                    string extension = Path.GetExtension(importPathTextBox.Text);

                    if (extension != ".txt")
                    {
                        throw new Exception("Nepodporovan� form�t. Program podporuje pouze textov� soubor");
                    }

                    FileText = await FileHandler.ReadAsync(importPathTextBox.Text, cts.Token);
                    formatter.SetText(FileText);
                    SetActionButtonsState(true);
                    saveFileButton.Enabled = true;

                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Soubor v po��dku nahr�n!";
                }
                catch (OperationCanceledException)
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = "Operace byla zru�ena!";
                    SetActionButtonsState(false);
                }
                catch (Exception ex)
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = ex.Message;
                    formatter.SetText(string.Empty);
                    saveFileButton.Enabled = false;
                    SetActionButtonsState(false);
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
                statusLabel.Text = "Odstra�uji diakritiku...";
                await Task.Run(() => formatter.RemoveDiacritic(cts.Token));
                SetActionButtonsState(true);
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Diakritika odstran�na!";

            }
            catch (OperationCanceledException)
            {

                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zru�ena!";
                SetActionButtonsState(false);
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                SetActionButtonsState(false);
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
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
                statusLabel.Text = "Odstra�uji mezery a interpunkci, implementuji CamelCase notaci na slova...";
                await Task.Run(() => formatter.RemoveSpacesAndPunctuation(cts.Token));
                SetActionButtonsState(true);
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Mezery a interpunkce odstran�na a slova p�etransformov�na na CamelCase!";

            }
            catch (OperationCanceledException)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Operace byla zru�ena!";
                SetActionButtonsState(false);
            }
            catch (Exception ex)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = ex.Message;
                SetActionButtonsState(false);
            }
            finally
            {
                cts.Dispose();
                cancelButton.Enabled = false;
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
                statusLabel.Text = "��dn� proces";
            }

            // Process was cancelled, set progressBar to 0
            importExportProgressBar.Value = 0;
            progressBarLabel.Text = "0%";
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