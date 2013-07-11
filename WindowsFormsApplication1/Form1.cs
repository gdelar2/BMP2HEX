using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Drawing;
using System.IO;
namespace BMP2HEX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imagePath="randomText";

           
           // while(!(imagePath.Substring((imagePath.Length)-3,3).Equals("bmp") )){
                    OpenFileDialog file = new OpenFileDialog();
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        imagePath = file.FileName;
                        textBox1.Text = imagePath;
                    }
           

           

            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string fileExt = textBox1.Text.Substring((textBox1.Text.Length) - 3, 3);

            if (!textBox1.Text.Equals(""))
            {

                Image img = Image.FromFile(textBox1.Text);

                byte[] byteArray = new byte[0];
                using (MemoryStream stream = new MemoryStream())
                {

                    switch (fileExt)
                    {
                        case "jpg":
                            img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case "bmp":
                            img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case "png":
                            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                            break;

                            

                    }

                    //img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    stream.Close();

                    byteArray = stream.ToArray();
                }

                richTextBox1.Text = BitConverter.ToString(byteArray);
                richTextBox1.Text = richTextBox1.Text.Replace("-", @" ");


                
            }

        }

        


    }
}
