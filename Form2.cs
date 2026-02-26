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

namespace WindowsFormsApp18
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //Delete the entire file
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GlobalData.FilePath;

            if (File.Exists(path))
                File.Delete(path); 

            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
        //Go to the national code search file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        //Close the entire program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
