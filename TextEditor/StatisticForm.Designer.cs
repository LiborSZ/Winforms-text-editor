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
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sentenceLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.charLabel = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.sentenceCounter = new System.Windows.Forms.Label();
            this.wordCounter = new System.Windows.Forms.Label();
            this.charCounter = new System.Windows.Forms.Label();
            this.rowCounter = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.Button();
            this.removeDiacriticButton = new System.Windows.Forms.Button();
            this.removeEmptyRowsButton = new System.Windows.Forms.Button();
            this.removeSpacesPuncButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.importPathTextBox = new System.Windows.Forms.TextBox();
            this.importPathLabel = new System.Windows.Forms.Label();
            this.fileBrowseButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.importExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.counterLabelsGroupBox = new System.Windows.Forms.GroupBox();
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.counterLabelsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.DefaultExt = "txt";
            this.OpenFileDialog.Filter = "\"txt files (*.txt)|*.txt;";
            this.OpenFileDialog.InitialDirectory = "Environment.GetFolderPath(Environment.SpecialFolder.Desktop)";
            this.OpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImportOpenFileDialog_FileOk);
            // 
            // sentenceLabel
            // 
            this.sentenceLabel.AutoSize = true;
            this.sentenceLabel.Location = new System.Drawing.Point(21, 31);
            this.sentenceLabel.Name = "sentenceLabel";
            this.sentenceLabel.Size = new System.Drawing.Size(59, 15);
            this.sentenceLabel.TabIndex = 0;
            this.sentenceLabel.Text = "Počet vět:";
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(21, 60);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(64, 15);
            this.wordLabel.TabIndex = 1;
            this.wordLabel.Text = "Počet slov:";
            // 
            // charLabel
            // 
            this.charLabel.AutoSize = true;
            this.charLabel.Location = new System.Drawing.Point(20, 89);
            this.charLabel.Name = "charLabel";
            this.charLabel.Size = new System.Drawing.Size(74, 15);
            this.charLabel.TabIndex = 2;
            this.charLabel.Text = "Počet znaků:";
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(21, 118);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(73, 15);
            this.rowLabel.TabIndex = 3;
            this.rowLabel.Text = "Počet řádků:";
            // 
            // sentenceCounter
            // 
            this.sentenceCounter.AutoSize = true;
            this.sentenceCounter.Location = new System.Drawing.Point(105, 31);
            this.sentenceCounter.Name = "sentenceCounter";
            this.sentenceCounter.Size = new System.Drawing.Size(13, 15);
            this.sentenceCounter.TabIndex = 4;
            this.sentenceCounter.Text = "0";
            // 
            // wordCounter
            // 
            this.wordCounter.AutoSize = true;
            this.wordCounter.Location = new System.Drawing.Point(105, 60);
            this.wordCounter.Name = "wordCounter";
            this.wordCounter.Size = new System.Drawing.Size(13, 15);
            this.wordCounter.TabIndex = 5;
            this.wordCounter.Text = "0";
            // 
            // charCounter
            // 
            this.charCounter.AutoSize = true;
            this.charCounter.Location = new System.Drawing.Point(104, 89);
            this.charCounter.Name = "charCounter";
            this.charCounter.Size = new System.Drawing.Size(13, 15);
            this.charCounter.TabIndex = 6;
            this.charCounter.Text = "0";
            // 
            // rowCounter
            // 
            this.rowCounter.AutoSize = true;
            this.rowCounter.Location = new System.Drawing.Point(104, 118);
            this.rowCounter.Name = "rowCounter";
            this.rowCounter.Size = new System.Drawing.Size(13, 15);
            this.rowCounter.TabIndex = 7;
            this.rowCounter.Text = "0";
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(27, 99);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(185, 23);
            this.copyButton.TabIndex = 8;
            this.copyButton.Text = "Překopíruj";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // removeDiacriticButton
            // 
            this.removeDiacriticButton.Location = new System.Drawing.Point(27, 128);
            this.removeDiacriticButton.Name = "removeDiacriticButton";
            this.removeDiacriticButton.Size = new System.Drawing.Size(185, 23);
            this.removeDiacriticButton.TabIndex = 9;
            this.removeDiacriticButton.Text = "Odstraň diakritiku";
            this.removeDiacriticButton.UseVisualStyleBackColor = true;
            this.removeDiacriticButton.Click += new System.EventHandler(this.RemoveDiacriticButton_Click);
            // 
            // removeEmptyRowsButton
            // 
            this.removeEmptyRowsButton.Location = new System.Drawing.Point(27, 157);
            this.removeEmptyRowsButton.Name = "removeEmptyRowsButton";
            this.removeEmptyRowsButton.Size = new System.Drawing.Size(185, 23);
            this.removeEmptyRowsButton.TabIndex = 10;
            this.removeEmptyRowsButton.Text = "Odstraň prázdné řádky";
            this.removeEmptyRowsButton.UseVisualStyleBackColor = true;
            this.removeEmptyRowsButton.Click += new System.EventHandler(this.RemoveEmptyRowsButton_Click);
            // 
            // removeSpacesPuncButton
            // 
            this.removeSpacesPuncButton.Location = new System.Drawing.Point(27, 186);
            this.removeSpacesPuncButton.Name = "removeSpacesPuncButton";
            this.removeSpacesPuncButton.Size = new System.Drawing.Size(185, 23);
            this.removeSpacesPuncButton.TabIndex = 11;
            this.removeSpacesPuncButton.Text = "Odstraň mezery a interpunkci";
            this.removeSpacesPuncButton.UseVisualStyleBackColor = true;
            this.removeSpacesPuncButton.Click += new System.EventHandler(this.RemoveSpacesPuncButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(27, 324);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(88, 23);
            this.saveFileButton.TabIndex = 12;
            this.saveFileButton.Text = "Uložit soubor";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(593, 324);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 13;
            this.closeButton.Text = "Zavřít";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(121, 324);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Zrušit";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
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
            this.fileBrowseButton.Click += new System.EventHandler(this.FileBrowseButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.Location = new System.Drawing.Point(27, 274);
            this.statusLabel.MaximumSize = new System.Drawing.Size(620, 50);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(49, 19);
            this.statusLabel.TabIndex = 18;
            this.statusLabel.Text = "Status";
            // 
            // importExportProgressBar
            // 
            this.importExportProgressBar.Location = new System.Drawing.Point(27, 245);
            this.importExportProgressBar.Name = "importExportProgressBar";
            this.importExportProgressBar.Size = new System.Drawing.Size(587, 23);
            this.importExportProgressBar.TabIndex = 19;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "txt";
            this.SaveFileDialog.FileName = "TextFile";
            this.SaveFileDialog.Filter = "\"txt files (*.txt)|*.txt|All files (*.*)|*.*\";";
            this.SaveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ExportSaveFileDialog_FileOk);
            // 
            // counterLabelsGroupBox
            // 
            this.counterLabelsGroupBox.Controls.Add(this.rowLabel);
            this.counterLabelsGroupBox.Controls.Add(this.sentenceLabel);
            this.counterLabelsGroupBox.Controls.Add(this.wordLabel);
            this.counterLabelsGroupBox.Controls.Add(this.charLabel);
            this.counterLabelsGroupBox.Controls.Add(this.sentenceCounter);
            this.counterLabelsGroupBox.Controls.Add(this.wordCounter);
            this.counterLabelsGroupBox.Controls.Add(this.charCounter);
            this.counterLabelsGroupBox.Controls.Add(this.rowCounter);
            this.counterLabelsGroupBox.Location = new System.Drawing.Point(497, 72);
            this.counterLabelsGroupBox.Name = "counterLabelsGroupBox";
            this.counterLabelsGroupBox.Size = new System.Drawing.Size(171, 153);
            this.counterLabelsGroupBox.TabIndex = 20;
            this.counterLabelsGroupBox.TabStop = false;
            this.counterLabelsGroupBox.Text = "Statistika";
            // 
            // progressBarLabel
            // 
            this.progressBarLabel.AutoSize = true;
            this.progressBarLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.progressBarLabel.Location = new System.Drawing.Point(620, 246);
            this.progressBarLabel.Name = "progressBarLabel";
            this.progressBarLabel.Size = new System.Drawing.Size(33, 21);
            this.progressBarLabel.TabIndex = 21;
            this.progressBarLabel.Text = "0%";
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(694, 358);
            this.Controls.Add(this.progressBarLabel);
            this.Controls.Add(this.counterLabelsGroupBox);
            this.Controls.Add(this.importExportProgressBar);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.fileBrowseButton);
            this.Controls.Add(this.importPathLabel);
            this.Controls.Add(this.importPathTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.removeSpacesPuncButton);
            this.Controls.Add(this.removeEmptyRowsButton);
            this.Controls.Add(this.removeDiacriticButton);
            this.Controls.Add(this.copyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StatisticForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor textu";
            this.counterLabelsGroupBox.ResumeLayout(false);
            this.counterLabelsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog OpenFileDialog;
        private Label sentenceLabel;
        private Label wordLabel;
        private Label charLabel;
        private Label rowLabel;
        private Label sentenceCounter;
        private Label wordCounter;
        private Label charCounter;
        private Label rowCounter;
        private Button copyButton;
        private Button removeDiacriticButton;
        private Button removeEmptyRowsButton;
        private Button removeSpacesPuncButton;
        private Button saveFileButton;
        private Button closeButton;
        private Button cancelButton;
        private TextBox importPathTextBox;
        private Label importPathLabel;
        private Button fileBrowseButton;
        private Label statusLabel;
        private ProgressBar importExportProgressBar;
        private SaveFileDialog SaveFileDialog;
        private GroupBox counterLabelsGroupBox;
        private Label progressBarLabel;
    }
}