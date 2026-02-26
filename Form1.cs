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
    public partial class Form1 : Form
    {
        string Path = @"C:\Users\CityTeck\Documents\پروژه بازی سازی\Patient.txt";
        public Form1()
        {
            InitializeComponent();
            cmbDeasese.Visible = false;
            cbdeasese.CheckedChanged += (s, e) =>
            {
                cmbDeasese.Visible = cbdeasese.Checked;
            };
        }
        private void cbdeasese_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnexit1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 nextform = new Form2();
            nextform.ShowDialog();
        }
        //Record information in a file
        private void btnEnter_Click_1(object sender, EventArgs e)
        {
            StreamWriter sw;
            if (File.Exists(Path))
                sw = File.AppendText(Path);
            else
                sw = File.CreateText(Path);

            sw.WriteLine("کدملی :" + tbNationalcode.Text);
            sw.WriteLine("نام و نام خانواگی:" + tbName.Text);
            if (rbFemale.Checked)
                sw.WriteLine("جنسیت:" + rbFemale.Text);
            else if (rbMan.Checked)
                sw.WriteLine("جنسیت:" + rbMan.Text);
            if (cmbDeasese.Visible == true)
            {
                sw.WriteLine("سابقه بیماری :" + cmbDeasese.Text);
            }
            sw.WriteLine("--------------------------------------------------------");
            sw.Close();
        }
        //Print information
        private void btprint_Click_1(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();

            string info = $"نام: {tbName.Text}\nکد ملی: {tbNationalcode.Text}\n" +
                          $"جنسیت: {(rbMan.Checked ? "مرد" : rbFemale.Checked ? "زن" : "نامشخص")}\n" +
                          $"سابقه بیماری: {(cbdeasese.Checked ? "بله" : "خیر")}\n" +
                          $"نوع بیماری: {(cbdeasese.Checked ? cmbDeasese.SelectedItem.ToString() : "ندارد")}";

            doc.PrintPage += (s, a) =>
            {
                a.Graphics.DrawString(info, new System.Drawing.Font("Tahoma", 12), System.Drawing.Brushes.Black, 100, 100);
            };

            previewDialog.Document = doc;
            previewDialog.ShowDialog();
        }
    }
}
