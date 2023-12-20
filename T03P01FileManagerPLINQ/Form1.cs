using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace T02P02FileManager
{
    public partial class Form1 : Form
    {
        string settingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "MyFileManagerSettings.dat");

        Settings settings = new Settings();

        public Form1()
        {
            InitializeComponent();
            RestoreSettings();
        }

        private void lbFiles_MouseClick(object sender, MouseEventArgs e)
        {
            string selected = lbFiles.SelectedItem.ToString();
            string filepath = Path.Combine(tbFilePath.Text, selected);

            if (!File.Exists(filepath) || Path.GetExtension(filepath) != ".txt")
                return;

            GetTextStats(filepath);
        }

        private void ClearText(ref string text)
        {
            text = text.Replace(".", "")
                .Replace(",", "").Replace("; ", " ")
                .Replace(" - ", " ").Replace(" – ", " ")
                .Replace("(", "").Replace(")", "")
                .Replace('\n', ' ').Replace('\r', ' ')
                .Replace("?", "").Replace("!", "").
                Replace("«", "").Replace("»", "");

            text = Regex.Replace(text, @"\[\d+\]", " ");
        }

        private void GetTextStats(string filepath)
        {
            if (!File.Exists(filepath))
                return;

            string[] delimeters = {" ", "", "-", "–",
                "...", ".", ",", ";", "\n", "\r"};
            string text = File.ReadAllText(filepath).ToLower();
            int linesCount = text.Count(x => x == '\n') + 1;

            ClearText(ref text);

            string[] words = text.Split()
                .Where(val => !delimeters.Contains(val)).ToArray();

            int wordsCount = words.Count();

            var sub = from w in words.AsParallel()
                      where w.Length >= 5
                      group w by w into g
                      let wordCnt = g.Count()
                      orderby wordCnt descending
                      select new { Word = g.Key, Count = wordCnt };

            lStats.Text = ("Lines count: " + linesCount +
                "\nWords count: " + wordsCount);
            lStats.Text += "\nTop-10 words >=5 letters by frequency:";
            int cnt = 0;
            foreach (var x in sub)
            {
                cnt++;
                lStats.Text += ("\n" + cnt + ") " + x.Word + " " + x.Count);
                if (cnt >= 10) break;
            }
        }

        private void RestoreSettings()
        {
            if (!File.Exists(settingsPath))
                return;

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(settingsPath, FileMode.Open))
                {
                    settings = (Settings)formatter.Deserialize(fs);
                    settings.Apply(this);
                }
            }
            catch (Exception e)
            {
                (File.Create(settingsPath)).Close();
            }
            
        }

        private string GetFilePathWithoutExtension(string filePath)
        {
            return Path.Combine(Path.GetDirectoryName(filePath), 
                Path.GetFileNameWithoutExtension(filePath));
        }

        private void Update_lbFiles()
        {
            Update_lbFiles(tbFilePath.Text);
        }
        private void Update_lbFiles(string filePath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(filePath);
                DirectoryInfo[] dirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                lbFiles.Items.Clear();

                foreach (DirectoryInfo curDir in dirs)
                {
                    lbFiles.Items.Add(curDir);
                }

                foreach (FileInfo curFile in files)
                {
                    lbFiles.Items.Add(curFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bGo_Click(object sender, EventArgs e)
        {
            Update_lbFiles();
        }

        private void lbFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string nextPath = lbFiles.SelectedItem.ToString();
            if (File.Exists(Path.Combine(tbFilePath.Text, nextPath)))
            {
                MessageBox.Show("Выбран файл, а не папка");
                return;
            }
            tbFilePath.Text = Path.Combine(tbFilePath.Text, nextPath);

            Update_lbFiles();
        }

        private string GetPreviousDirectory(string filePath)
        {
            do
            {
                filePath = filePath.Remove(filePath.Length - 1);
            }
            while (filePath[filePath.Length - 1] != '\\');

            return filePath;
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            string filePath = tbFilePath.Text;

            filePath = GetPreviousDirectory(filePath);

            tbFilePath.Text = filePath;

            Update_lbFiles();
        }

        private void bChooseDrive_Click(object sender, EventArgs e)
        {
            if (cbDrives.SelectedItem == null)
                return;

            tbFilePath.Text = Path.Combine(cbDrives.SelectedItem.ToString());
            Update_lbFiles();
        }

        private void RenameFile(FileInfo file)
        {
            try
            {
                string filePath = file.DirectoryName;

                InputBox inputBox = new InputBox();
                string newFileName = file.Name;
                inputBox.tbAnswer.Text = newFileName;

                if (inputBox.ShowDialog(this) == DialogResult.OK)
                    newFileName = inputBox.GetAnswer();

                inputBox.Dispose();

                File.Move(Path.Combine(filePath, file.Name),
                    Path.Combine(filePath, newFileName));

                MessageBox.Show("Renamed: " + newFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RenameDirectory(DirectoryInfo dir)
        {
            try
            {
                string filePath = GetPreviousDirectory(dir.FullName);

                InputBox inputBox = new InputBox();
                string newDirName = dir.Name;
                inputBox.tbAnswer.Text = newDirName;

                if (inputBox.ShowDialog(this) == DialogResult.OK)
                    newDirName = inputBox.GetAnswer();

                inputBox.Dispose();

                Directory.Move(Path.Combine(filePath, dir.Name),
                    Path.Combine(filePath, newDirName));

                MessageBox.Show("Renamed: " + newDirName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bRename_Click(object sender, EventArgs e)
        {
            try
            {
                object obj = lbFiles.SelectedItem;

                if (obj is FileInfo file)
                {
                    RenameFile(file);
                }
                else if (obj is DirectoryInfo curDir)
                {
                    RenameDirectory(curDir);
                }

                Update_lbFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            try
            {
                object obj = lbFiles.SelectedItem;
                if (obj == null)
                    return;

                if (obj is FileInfo file)
                    File.Delete(file.FullName);
                else if (obj is DirectoryInfo dir)
                    Directory.Delete(dir.FullName, true);

                Update_lbFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                InputBox inputBox = new InputBox();
                string fileName = "tmp.txt";

                string path = tbFilePath.Text;

                if (inputBox.ShowDialog(this) != DialogResult.OK)
                    return;

                fileName = inputBox.GetAnswer();
                var newFile = File.Create(Path.Combine(path, fileName));
                newFile.Close();

                Update_lbFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ArchivateDirectory(string dir)
        {
            string curPath = dir;
            string zipPath = dir + ".zip";
            ZipFile.CreateFromDirectory(curPath, zipPath);
        }

        private void bArchivate_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = lbFiles.SelectedItem;
                if (obj == null)
                    return;

                if (obj is DirectoryInfo dir)
                {
                    ArchivateDirectory(dir.FullName);
                }
                else if (obj is FileInfo file)
                {
                    string dirPath = GetFilePathWithoutExtension(file.FullName);
                    Directory.CreateDirectory(dirPath);
                    File.Move(file.FullName, Path.Combine(dirPath, file.Name));

                    ArchivateDirectory(dirPath);

                    Directory.Delete(dirPath, true);
                }

                Update_lbFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void bExtract_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbFiles.SelectedItem == null)
                    return;

                string curPath = "";
                string zipPath = "";
                if (lbFiles.SelectedItem is FileInfo zipFile)
                {
                    curPath = GetFilePathWithoutExtension(zipFile.FullName);

                    zipPath = zipFile.FullName;

                    ZipFile.ExtractToDirectory(zipPath, curPath);
                }

                Update_lbFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bRelocate_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = lbFiles.SelectedItem;

                if (obj == null)
                    return;

                InputBox inputBox = new InputBox();
                if (inputBox.ShowDialog(this) != DialogResult.OK)
                    return;

                string destPath = "";

                if (obj is FileInfo file)
                {
                    destPath = Path.Combine(inputBox.GetAnswer(), file.Name);
                    File.Move(file.FullName, destPath);
                }
                else if (obj is DirectoryInfo dir)
                {
                    destPath = Path.Combine(inputBox.GetAnswer(), dir.Name);
                    Directory.Move(dir.FullName, destPath);
                }

                Update_lbFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            try
            {
                var dir = new DirectoryInfo(sourceDir);

                if (!dir.Exists)
                    throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

                DirectoryInfo[] dirs = dir.GetDirectories();

                Directory.CreateDirectory(destinationDir);

                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(destinationDir, file.Name);
                    file.CopyTo(targetFilePath);
                }

                if (recursive)
                {
                    foreach (DirectoryInfo subDir in dirs)
                    {
                        string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                        CopyDirectory(subDir.FullName, newDestinationDir, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bCopyTo_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = lbFiles.SelectedItem;

                if (obj == null)
                    return;

                InputBox inputBox = new InputBox();
                if (inputBox.ShowDialog(this) != DialogResult.OK)
                    return;

                string destPath = "";

                if (obj is FileInfo file)
                {
                    destPath = Path.Combine(inputBox.GetAnswer(), file.Name);
                    File.Copy(file.FullName, destPath);
                }
                else if (obj is DirectoryInfo dir)
                {
                    destPath = Path.Combine(inputBox.GetAnswer(), dir.Name);
                    CopyDirectory(dir.FullName, destPath, true);
                }

                Update_lbFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                InputBox inputBox = new InputBox();
                string dirName = "tmp";

                string path = tbFilePath.Text;

                if (inputBox.ShowDialog(this) != DialogResult.OK)
                    return;

                dirName = inputBox.GetAnswer();
                Directory.CreateDirectory(Path.Combine(path, dirName));

                Update_lbFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = this.Font;
            fontDialog1.Color = this.ForeColor;

            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            this.Font = fontDialog1.Font;
            this.ForeColor = fontDialog1.Color;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Set(this);
            settings.Serialize(settingsPath);
        }
    }
}
