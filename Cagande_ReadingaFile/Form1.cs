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

namespace Cagande_ReadingaFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            DisplayTolist();
        }
        private void DisplayTolist()
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            openFileDialog1.ShowDialog(); 

            string path = openFileDialog1.FileName; 

            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        lvShowText.Items.Add(line); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Selected file does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
