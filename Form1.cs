using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{
    public partial class Form1 : Form
    {
        private string _filePath = null;
        private bool _fileSaved = true;
        public Form1()
        {
            InitializeComponent();
            g = canvasOutput.CreateGraphics();
        }

        Graphics g;
        private void btnRun_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textProgramBox.Lines.Length; i++)
            {
                Parser.parse(textProgramBox.Lines[i], g);
            }
        }

        private void textCmdLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Parser.parse(textCmdLine.Text, g);
                e.SuppressKeyPress = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Gray);
            textCmdLine.Text = "";
            textProgramBox.Text = "";
            Parser.clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_fileSaved)
            {
                DialogResult dialogResult = MessageBox.Show("Save current file before proceeding?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!saveFile())
                        return;
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "gpl files (*.gpl)|*.gpl|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        textProgramBox.Text = reader.ReadToEnd();
                    }

                    _fileSaved = true;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(this, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_fileSaved)
            {
                DialogResult dialogResult = MessageBox.Show("Save current file before proceeding?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!saveFile())
                        return;
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            Application.Exit();
        }

        private void textProgramBox_TextChanged(object sender, EventArgs e)
        {
            _fileSaved = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = textProgramBox.Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "gpl files (*.gpl)|*.gpl|All files (*.*)|*.*";
            saveFileDialog.Title = "Save GPL";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                _filePath = saveFileDialog.FileName;
                using (StreamWriter sw = new StreamWriter(_filePath))
                    sw.WriteLine(code);
                _fileSaved = true;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textProgramBox.SelectedText);

            textProgramBox.SelectedText = string.Empty;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textProgramBox.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string xx = Clipboard.GetText();

            textProgramBox.Text = textProgramBox.Text.Insert(textProgramBox.SelectionStart, xx);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textProgramBox.SelectedText = string.Empty;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textProgramBox.WordWrap = !textProgramBox.WordWrap;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_fileSaved)
            {
                DialogResult dialogResult = MessageBox.Show("Save current file before proceeding?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!saveFile())
                        e.Cancel = true;
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private bool saveFile()
        {
            string code = textProgramBox.Text;
            if (_filePath == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "gpl files (*.gpl)|*.gpl|All files (*.*)|*.*";
                saveFileDialog.Title = "Save GPL";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    _filePath = saveFileDialog.FileName;
                    using (StreamWriter sw = new StreamWriter(_filePath))
                        sw.WriteLine(code);
                    _fileSaved = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                using (StreamWriter sw = new StreamWriter(_filePath))
                    sw.WriteLine(code);
                _fileSaved = true;
                return true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed By:-\nAshutosh Sharma\n Version: 1.0.0", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
