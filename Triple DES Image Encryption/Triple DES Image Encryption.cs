using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;

namespace Triple_DES_Image_Encryption
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            // Create a material theme manager and add the form to manage(this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Configure color schema
            /*materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400,
                Primary.Blue500,
                Primary.Blue500,
                Accent.LightBlue200,
                TextShade.WHITE

            );*/
        }

        
        private void materialFlatButton1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.Multiselect = true;
            OD.CheckFileExists = true;
            OD.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.gif, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.gif; *.jfif; *.png";
            //OD.Filter = "All Files|*";
            OD.FileName = "";

            if (OD.ShowDialog() == DialogResult.OK)
            {
                //materialSingleLineTextField1.Text = OD.FileName;
                //listBox1.Items.Clear();

                foreach (string file in OD.FileNames)
                {
                    if (!listBox1.Items.Contains(file))
                    {
                        listBox1.Items.Add(file);
                        listBox1.Text = OD.FileName;
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.Multiselect = true;
            OD.CheckFileExists = true;
            OD.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.gif, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.gif; *.jfif; *.png";
            //OD.Filter = "All Files|*";
            OD.FileName = "";

            if (OD.ShowDialog() == DialogResult.OK)
            {
                //materialSingleLineTextField1.Text = OD.FileName;
                //listBox1.Items.Clear();

                foreach (string file in OD.FileNames)
                {
                    if (!listBox1.Items.Contains(file))
                    {
                        listBox1.Items.Add(file);
                        listBox1.Text = OD.FileName;
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TripleDES tDES = new TripleDES(materialSingleLineTextField2.Text);
                //tDES.EncryptFile(materialSingleLineTextField1.Text);
                string[] items = new string[] { };

                foreach (string item in listBox1.Items)
                {
                    items = items.Concat(new[] {item}).ToArray();
                    //MessageBox.Show(item);
                }

                tDES.EncryptFile(items);
                GC.Collect();
                _ = MessageBox.Show("Images Encrypted");
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
                TripleDES tDES = new TripleDES(materialSingleLineTextField2.Text);
                //tDES.EncryptFile(materialSingleLineTextField1.Text);
                string[] items = new string[] { };

                foreach (string item in listBox1.Items)
                {
                    items = items.Concat(new[] { item }).ToArray();
                    //MessageBox.Show(item);
                }

                tDES.DecryptFile(items);
                GC.Collect();
                _ = MessageBox.Show("Images Decrypted");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (pictureBox1.Image == null)
            {
                this.pictureBox1.Image = Image.FromFile(listBox1.SelectedItem.ToString());
            }
            else
            {
                this.pictureBox1.Image.Dispose();
                this.pictureBox1.Image = null;
            }
            /*pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            pictureBox1.ImageLocation = null;*/
            pictureBox1.Update();
            pictureBox1.Refresh();

            /*ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = l.SelectedIndex;
                listBox1.Text = listBox1.SelectedIndex.ToString();
                LoadPicture();
            }*/
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            //listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        
        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }





        /*private void Form1_Load(object sender, EventArgs e)
{
    this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
    this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
}*/

        /*private void button3_Click(object sender, EventArgs e)
        {
            //listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.Remove(listBox1.SelectedItem);

        }*/

        /*private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (!listBox1.Items.Contains(s[i]))
                {
                    listBox1.Items.Add(s[i]);
                }
            }
                
        }*/

    }
}
