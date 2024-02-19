using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment5_Notepad
{
    public partial class Form1 : Form
    {
        private string currentFilePath;
        public Form1()
        {
            InitializeComponent();
        }
        private void newStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTxtBox.Text = string.Empty;
            currentFilePath = null;
        }
        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    richTxtBox.Text = File.ReadAllText(currentFilePath);
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(currentFilePath, richTxtBox.Text);
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                    File.WriteAllText(currentFilePath, richTxtBox.Text);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
