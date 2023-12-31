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

namespace HashVerify
{
    
    public partial class Form1 : Form
    {
        private string selectedFilePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                textBox2.Text = "Please select a file before computing hashes.";
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(selectedFilePath);

                if (radioButton1.Checked)
                {
                    string sha256Hash = RadioButtonMethods.ComputeSha256Hash(fileContent);
                    textBox2.Text = sha256Hash;
                }
                else if (radioButton2.Checked)
                {
                    string md5Hash = RadioButtonMethods.ComputeMd5Hash(fileContent);
                    textBox2.Text = md5Hash;
                }
                else if (radioButton4.Checked)
                {
                    string sha512 = RadioButtonMethods.ComputeSha512(fileContent); 
                    textBox2.Text = sha512;
                }
                else
                {
                    textBox2.Text = "No hash algorithm selected";
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = $"Error reading or hashing file: {ex.Message}";
            }
        }

        // grabs the file name, and can be modified to hash a dir if needed.

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*"; 

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileNameWithoutExtension(selectedFilePath);

                    textBox1.Text = fileName;
                }
            }
        }

    }
}
