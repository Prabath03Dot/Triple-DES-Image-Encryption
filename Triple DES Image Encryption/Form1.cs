using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triple_DES_Image_Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            //OD.Filter = "All Files|*";
            OD.FileName = "";
            if (OD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = OD.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TripleDES tDES = new TripleDES(textBox2.Text);
                tDES.EncryptFile(textBox1.Text);
                GC.Collect();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TripleDES tDES = new TripleDES(textBox2.Text);
                tDES.DecryptFile(textBox1.Text);
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
