
namespace T02P02FileManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.bGo = new System.Windows.Forms.Button();
            this.cbDrives = new System.Windows.Forms.ComboBox();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.bBack = new System.Windows.Forms.Button();
            this.bChooseDrive = new System.Windows.Forms.Button();
            this.bRename = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bCreateFile = new System.Windows.Forms.Button();
            this.bCreateDirectory = new System.Windows.Forms.Button();
            this.bArchivate = new System.Windows.Forms.Button();
            this.bExtract = new System.Windows.Forms.Button();
            this.bRelocate = new System.Windows.Forms.Button();
            this.bCopyTo = new System.Windows.Forms.Button();
            this.bSettings = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.pStats = new System.Windows.Forms.Panel();
            this.lStats = new System.Windows.Forms.Label();
            this.pStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.ItemHeight = 16;
            this.lbFiles.Location = new System.Drawing.Point(16, 64);
            this.lbFiles.Margin = new System.Windows.Forms.Padding(4);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(748, 452);
            this.lbFiles.TabIndex = 0;
            this.lbFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbFiles_MouseClick);
            this.lbFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFiles_MouseDoubleClick);
            // 
            // bGo
            // 
            this.bGo.Location = new System.Drawing.Point(772, 16);
            this.bGo.Margin = new System.Windows.Forms.Padding(4);
            this.bGo.Name = "bGo";
            this.bGo.Size = new System.Drawing.Size(100, 28);
            this.bGo.TabIndex = 1;
            this.bGo.Text = "Go";
            this.bGo.UseVisualStyleBackColor = true;
            this.bGo.Click += new System.EventHandler(this.bGo_Click);
            // 
            // cbDrives
            // 
            this.cbDrives.FormattingEnabled = true;
            this.cbDrives.Location = new System.Drawing.Point(91, 15);
            this.cbDrives.Margin = new System.Windows.Forms.Padding(4);
            this.cbDrives.Name = "cbDrives";
            this.cbDrives.Size = new System.Drawing.Size(93, 24);
            this.cbDrives.TabIndex = 2;
            // 
            // tbFilePath
            // 
            this.tbFilePath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbFilePath.Location = new System.Drawing.Point(391, 16);
            this.tbFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(373, 23);
            this.tbFilePath.TabIndex = 3;
            this.tbFilePath.Text = "C:\\\\Users\\User\\Desktop";
            // 
            // bBack
            // 
            this.bBack.Location = new System.Drawing.Point(772, 52);
            this.bBack.Margin = new System.Windows.Forms.Padding(4);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(100, 28);
            this.bBack.TabIndex = 4;
            this.bBack.Text = "Back";
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bChooseDrive
            // 
            this.bChooseDrive.Location = new System.Drawing.Point(228, 3);
            this.bChooseDrive.Margin = new System.Windows.Forms.Padding(4);
            this.bChooseDrive.Name = "bChooseDrive";
            this.bChooseDrive.Size = new System.Drawing.Size(100, 54);
            this.bChooseDrive.TabIndex = 5;
            this.bChooseDrive.Text = "Choose drive";
            this.bChooseDrive.UseVisualStyleBackColor = true;
            this.bChooseDrive.Click += new System.EventHandler(this.bChooseDrive_Click);
            // 
            // bRename
            // 
            this.bRename.Location = new System.Drawing.Point(772, 114);
            this.bRename.Margin = new System.Windows.Forms.Padding(4);
            this.bRename.Name = "bRename";
            this.bRename.Size = new System.Drawing.Size(100, 28);
            this.bRename.TabIndex = 6;
            this.bRename.Text = "Rename";
            this.bRename.UseVisualStyleBackColor = true;
            this.bRename.Click += new System.EventHandler(this.bRename_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(772, 150);
            this.bDelete.Margin = new System.Windows.Forms.Padding(4);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(100, 28);
            this.bDelete.TabIndex = 6;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bCreateFile
            // 
            this.bCreateFile.Location = new System.Drawing.Point(895, 114);
            this.bCreateFile.Margin = new System.Windows.Forms.Padding(4);
            this.bCreateFile.Name = "bCreateFile";
            this.bCreateFile.Size = new System.Drawing.Size(100, 28);
            this.bCreateFile.TabIndex = 6;
            this.bCreateFile.Text = "Create file";
            this.bCreateFile.UseVisualStyleBackColor = true;
            this.bCreateFile.Click += new System.EventHandler(this.bCreateFile_Click);
            // 
            // bCreateDirectory
            // 
            this.bCreateDirectory.Location = new System.Drawing.Point(895, 150);
            this.bCreateDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.bCreateDirectory.Name = "bCreateDirectory";
            this.bCreateDirectory.Size = new System.Drawing.Size(143, 28);
            this.bCreateDirectory.TabIndex = 6;
            this.bCreateDirectory.Text = "Create directory";
            this.bCreateDirectory.UseVisualStyleBackColor = true;
            this.bCreateDirectory.Click += new System.EventHandler(this.bCreateFolder_Click);
            // 
            // bArchivate
            // 
            this.bArchivate.Location = new System.Drawing.Point(772, 209);
            this.bArchivate.Margin = new System.Windows.Forms.Padding(4);
            this.bArchivate.Name = "bArchivate";
            this.bArchivate.Size = new System.Drawing.Size(100, 28);
            this.bArchivate.TabIndex = 6;
            this.bArchivate.Text = "Archivate";
            this.bArchivate.UseVisualStyleBackColor = true;
            this.bArchivate.Click += new System.EventHandler(this.bArchivate_Click);
            // 
            // bExtract
            // 
            this.bExtract.Location = new System.Drawing.Point(880, 209);
            this.bExtract.Margin = new System.Windows.Forms.Padding(4);
            this.bExtract.Name = "bExtract";
            this.bExtract.Size = new System.Drawing.Size(100, 28);
            this.bExtract.TabIndex = 6;
            this.bExtract.Text = "Extract";
            this.bExtract.UseVisualStyleBackColor = true;
            this.bExtract.Click += new System.EventHandler(this.bExtract_Click);
            // 
            // bRelocate
            // 
            this.bRelocate.Location = new System.Drawing.Point(772, 245);
            this.bRelocate.Margin = new System.Windows.Forms.Padding(4);
            this.bRelocate.Name = "bRelocate";
            this.bRelocate.Size = new System.Drawing.Size(100, 28);
            this.bRelocate.TabIndex = 6;
            this.bRelocate.Text = "Relocate";
            this.bRelocate.UseVisualStyleBackColor = true;
            this.bRelocate.Click += new System.EventHandler(this.bRelocate_Click);
            // 
            // bCopyTo
            // 
            this.bCopyTo.Location = new System.Drawing.Point(880, 245);
            this.bCopyTo.Margin = new System.Windows.Forms.Padding(4);
            this.bCopyTo.Name = "bCopyTo";
            this.bCopyTo.Size = new System.Drawing.Size(100, 28);
            this.bCopyTo.TabIndex = 6;
            this.bCopyTo.Text = "Copy to";
            this.bCopyTo.UseVisualStyleBackColor = true;
            this.bCopyTo.Click += new System.EventHandler(this.bCopyTo_Click);
            // 
            // bSettings
            // 
            this.bSettings.Location = new System.Drawing.Point(893, 20);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(102, 60);
            this.bSettings.TabIndex = 7;
            this.bSettings.Text = "Settings";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.ShowColor = true;
            // 
            // pStats
            // 
            this.pStats.Controls.Add(this.lStats);
            this.pStats.Location = new System.Drawing.Point(780, 289);
            this.pStats.Name = "pStats";
            this.pStats.Size = new System.Drawing.Size(275, 253);
            this.pStats.TabIndex = 8;
            // 
            // lStats
            // 
            this.lStats.AutoSize = true;
            this.lStats.Location = new System.Drawing.Point(13, 4);
            this.lStats.Name = "lStats";
            this.lStats.Size = new System.Drawing.Size(40, 17);
            this.lStats.TabIndex = 0;
            this.lStats.Text = "Stats";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pStats);
            this.Controls.Add(this.bSettings);
            this.Controls.Add(this.bCreateDirectory);
            this.Controls.Add(this.bExtract);
            this.Controls.Add(this.bArchivate);
            this.Controls.Add(this.bCreateFile);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bCopyTo);
            this.Controls.Add(this.bRelocate);
            this.Controls.Add(this.bRename);
            this.Controls.Add(this.bChooseDrive);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.cbDrives);
            this.Controls.Add(this.bGo);
            this.Controls.Add(this.lbFiles);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "File Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.pStats.ResumeLayout(false);
            this.pStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button bGo;
        private System.Windows.Forms.ComboBox cbDrives;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bChooseDrive;
        private System.Windows.Forms.Button bRename;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bCreateFile;
        private System.Windows.Forms.Button bCreateDirectory;
        private System.Windows.Forms.Button bArchivate;
        private System.Windows.Forms.Button bExtract;
        private System.Windows.Forms.Button bRelocate;
        private System.Windows.Forms.Button bCopyTo;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Panel pStats;
        private System.Windows.Forms.Label lStats;
    }
}

