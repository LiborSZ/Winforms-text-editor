namespace TextEditor
{
    partial class StatisticForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.importOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SentenceLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.charLabel = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.SentenceCounter = new System.Windows.Forms.Label();
            this.wordCounter = new System.Windows.Forms.Label();
            this.charCounter = new System.Windows.Forms.Label();
            this.rowCounter = new System.Windows.Forms.Label();
            this.CopyButton = new System.Windows.Forms.Button();
            this.removeDiacriticButton = new System.Windows.Forms.Button();
            this.removeEmptyRowsButton = new System.Windows.Forms.Button();
            this.removeSpacesPuncButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.importPathTextBox = new System.Windows.Forms.TextBox();
            this.importPathLabel = new System.Windows.Forms.Label();
            this.fileBrowseButton = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.ImportExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.exportSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // importOpenFileDialog
            // 
            this.importOpenFileDialog.FileName = "openFileDialog1";
            this.importOpenFileDialog.InitialDirectory = "Environment.GetFolderPath(Environment.SpecialFolder.Desktop)";
            // 
            // SentenceLabel
            // 
            this.SentenceLabel.AutoSize = true;
            this.SentenceLabel.Location = new System.Drawing.Point(560, 103);
            this.SentenceLabel.Name = "SentenceLabel";
            this.SentenceLabel.Size = new System.Drawing.Size(56, 15);
            this.SentenceLabel.TabIndex = 0;
            this.SentenceLabel.Text = "Počet vět";
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(560, 132);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(61, 15);
            this.wordLabel.TabIndex = 1;
            this.wordLabel.Text = "Počet slov";
            // 
            // charLabel
            // 
            this.charLabel.AutoSize = true;
            this.charLabel.Location = new System.Drawing.Point(559, 161);
            this.charLabel.Name = "charLabel";
            this.charLabel.Size = new System.Drawing.Size(71, 15);
            this.charLabel.TabIndex = 2;
            this.charLabel.Text = "Počet znaků";
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(560, 190);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(70, 15);
            this.rowLabel.TabIndex = 3;
            this.rowLabel.Text = "Počet řádků";
            // 
            // SentenceCounter
            // 
            this.SentenceCounter.AutoSize = true;
            this.SentenceCounter.Location = new System.Drawing.Point(644, 103);
            this.SentenceCounter.Name = "SentenceCounter";
            this.SentenceCounter.Size = new System.Drawing.Size(13, 15);
            this.SentenceCounter.TabIndex = 4;
            this.SentenceCounter.Text = "0";
            // 
            // wordCounter
            // 
            this.wordCounter.AutoSize = true;
            this.wordCounter.Location = new System.Drawing.Point(644, 132);
            this.wordCounter.Name = "wordCounter";
            this.wordCounter.Size = new System.Drawing.Size(13, 15);
            this.wordCounter.TabIndex = 5;
            this.wordCounter.Text = "0";
            // 
            // charCounter
            // 
            this.charCounter.AutoSize = true;
            this.charCounter.Location = new System.Drawing.Point(643, 161);
            this.charCounter.Name = "charCounter";
            this.charCounter.Size = new System.Drawing.Size(13, 15);
            this.charCounter.TabIndex = 6;
            this.charCounter.Text = "0";
            // 
            // rowCounter
            // 
            this.rowCounter.AutoSize = true;
            this.rowCounter.Location = new System.Drawing.Point(643, 190);
            this.rowCounter.Name = "rowCounter";
            this.rowCounter.Size = new System.Drawing.Size(13, 15);
            this.rowCounter.TabIndex = 7;
            this.rowCounter.Text = "0";
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(27, 99);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(185, 23);
            this.CopyButton.TabIndex = 8;
            this.CopyButton.Text = "Překopíruj";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // removeDiacriticButton
            // 
            this.removeDiacriticButton.Location = new System.Drawing.Point(27, 128);
            this.removeDiacriticButton.Name = "removeDiacriticButton";
            this.removeDiacriticButton.Size = new System.Drawing.Size(185, 23);
            this.removeDiacriticButton.TabIndex = 9;
            this.removeDiacriticButton.Text = "Odstraň diakritiku";
            this.removeDiacriticButton.UseVisualStyleBackColor = true;
            this.removeDiacriticButton.Click += new System.EventHandler(this.removeDiacriticButton_Click);
            // 
            // removeEmptyRowsButton
            // 
            this.removeEmptyRowsButton.Location = new System.Drawing.Point(27, 157);
            this.removeEmptyRowsButton.Name = "removeEmptyRowsButton";
            this.removeEmptyRowsButton.Size = new System.Drawing.Size(185, 23);
            this.removeEmptyRowsButton.TabIndex = 10;
            this.removeEmptyRowsButton.Text = "Odstraň prázdné řádky";
            this.removeEmptyRowsButton.UseVisualStyleBackColor = true;
            this.removeEmptyRowsButton.Click += new System.EventHandler(this.removeEmptySpacesButton_Click);
            // 
            // removeSpacesPuncButton
            // 
            this.removeSpacesPuncButton.Location = new System.Drawing.Point(27, 186);
            this.removeSpacesPuncButton.Name = "removeSpacesPuncButton";
            this.removeSpacesPuncButton.Size = new System.Drawing.Size(185, 23);
            this.removeSpacesPuncButton.TabIndex = 11;
            this.removeSpacesPuncButton.Text = "Odstraň mezery a interpunkci";
            this.removeSpacesPuncButton.UseVisualStyleBackColor = true;
            this.removeSpacesPuncButton.Click += new System.EventHandler(this.removeSpacesPuncButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(27, 324);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(88, 23);
            this.SaveFileButton.TabIndex = 12;
            this.SaveFileButton.Text = "Uložit soubor";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(593, 324);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 13;
            this.closeButton.Text = "Zavřít";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(512, 324);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Zrušit";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // importPathTextBox
            // 
            this.importPathTextBox.Location = new System.Drawing.Point(128, 30);
            this.importPathTextBox.Name = "importPathTextBox";
            this.importPathTextBox.Size = new System.Drawing.Size(444, 23);
            this.importPathTextBox.TabIndex = 15;
            // 
            // importPathLabel
            // 
            this.importPathLabel.AutoSize = true;
            this.importPathLabel.Location = new System.Drawing.Point(27, 33);
            this.importPathLabel.Name = "importPathLabel";
            this.importPathLabel.Size = new System.Drawing.Size(95, 15);
            this.importPathLabel.TabIndex = 16;
            this.importPathLabel.Text = "Cesta k souboru:";
            // 
            // fileBrowseButton
            // 
            this.fileBrowseButton.Location = new System.Drawing.Point(578, 30);
            this.fileBrowseButton.Name = "fileBrowseButton";
            this.fileBrowseButton.Size = new System.Drawing.Size(90, 23);
            this.fileBrowseButton.TabIndex = 17;
            this.fileBrowseButton.Text = "Procházet...";
            this.fileBrowseButton.UseVisualStyleBackColor = true;
            this.fileBrowseButton.Click += new System.EventHandler(this.fileBrowseButton_Click);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fileNameLabel.Location = new System.Drawing.Point(27, 245);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(132, 19);
            this.fileNameLabel.TabIndex = 18;
            this.fileNameLabel.Text = "Název souboru.txt";
            // 
            // ImportExportProgressBar
            // 
            this.ImportExportProgressBar.Location = new System.Drawing.Point(27, 276);
            this.ImportExportProgressBar.Name = "ImportExportProgressBar";
            this.ImportExportProgressBar.Size = new System.Drawing.Size(629, 23);
            this.ImportExportProgressBar.TabIndex = 19;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 358);
            this.Controls.Add(this.ImportExportProgressBar);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.fileBrowseButton);
            this.Controls.Add(this.importPathLabel);
            this.Controls.Add(this.importPathTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.removeSpacesPuncButton);
            this.Controls.Add(this.removeEmptyRowsButton);
            this.Controls.Add(this.removeDiacriticButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.rowCounter);
            this.Controls.Add(this.charCounter);
            this.Controls.Add(this.wordCounter);
            this.Controls.Add(this.SentenceCounter);
            this.Controls.Add(this.rowLabel);
            this.Controls.Add(this.charLabel);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.SentenceLabel);
            this.Name = "StatisticForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog importOpenFileDialog;
        private Label SentenceLabel;
        private Label wordLabel;
        private Label charLabel;
        private Label rowLabel;
        private Label SentenceCounter;
        private Label wordCounter;
        private Label charCounter;
        private Label rowCounter;
        private Button CopyButton;
        private Button removeDiacriticButton;
        private Button removeEmptyRowsButton;
        private Button removeSpacesPuncButton;
        private Button SaveFileButton;
        private Button closeButton;
        private Button cancelButton;
        private TextBox importPathTextBox;
        private Label importPathLabel;
        private Button fileBrowseButton;
        private Label fileNameLabel;
        private ProgressBar ImportExportProgressBar;
        private SaveFileDialog exportSaveFileDialog;
    }
}