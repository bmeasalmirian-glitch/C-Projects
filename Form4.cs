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

namespace WindowsFormsApp18
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            btnPlay.Enabled = false;
            Form2 form2 = new Form2();
            form2.Close();
        }
        public static string currentUserNationalCode;
        private void tbEnter2_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string path = GlobalData.FilePath;
            //Checking the national code
            if (!File.Exists(path))
            {
                MessageBox.Show("کد ملی مورد نظر پیدا نشد.");
                return;
            }

            string[] lines = File.ReadAllLines(path);
            bool found = false;

            for (int i = 0; i < lines.Length;)
            {
                if (i + 2 >= lines.Length) break;

                string idLine = lines[i].Trim();         
                string nameLine = lines[i + 1].Trim();   
                string genderLine = lines[i + 2].Trim(); 

                string diseaseLine = "";
                string scoreLine = "";
                string separatorLine = "";

                int nextIndex = i + 3;

                // Check if the next line is a disease
                if (nextIndex < lines.Length && lines[nextIndex].StartsWith("سابقه بیماری"))
                {
                    diseaseLine = lines[nextIndex].Trim();
                    nextIndex++;
                }

                // Check if the next line is a score
                if (nextIndex < lines.Length && lines[nextIndex].StartsWith("امتیاز"))
                {
                    scoreLine = lines[nextIndex].Trim();
                    nextIndex++;
                }

                // Check if the next line is a separator
                if (nextIndex < lines.Length && lines[nextIndex].StartsWith("----"))
                {
                    separatorLine = lines[nextIndex];
                    nextIndex++;
                }

                // Check national code
                if (idLine.Replace("کدملی :", "").Trim() == tbSearchID.Text.Trim())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(idLine);
                    sb.AppendLine(nameLine);
                    sb.AppendLine(genderLine);

                    sb.AppendLine(!string.IsNullOrEmpty(diseaseLine) ? diseaseLine : "سابقه بیماری: ندارد");
                    sb.AppendLine(!string.IsNullOrEmpty(scoreLine) ? scoreLine : "امتیازی ثبت نشده");

                    richTextBox1.Text = sb.ToString();
                    currentUserNationalCode = idLine.Replace("کدملی :", "").Trim();
                    btnPlay.Enabled = true;
                    found = true;
                    break;
                }

                i = nextIndex;
            }

            if (!found)
            {
                MessageBox.Show("بیماری با این کد ملی پیدا نشد.");
            }
        }

        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 nextform = new Form3();
            nextform.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
