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
using System.Xml.Linq;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XElement fileDocument = XElement.Load(Path.Combine(Directory.GetCurrentDirectory(), @"Config\Files.xml"));

            if (Directory.Exists(@"E:\Temp\ECOM_Accurev"))
            {
                Directory.Delete(@"E:\Temp\ECOM_Accurev",true);                
            }
            Directory.CreateDirectory(@"E:\Temp\ECOM_Accurev");
            StringBuilder fileStatus = new StringBuilder();
            StringBuilder directoryStatus = new StringBuilder();

            foreach (XElement file in fileDocument.Descendants())
            {
                string fileName = file.Attribute("location").Value;
                string copyOverPartialPath = fileName.Substring(8);
                if (File.Exists(fileName))
                {
                    File.AppendAllText(fileName," ");
                    if (!Directory.Exists(Path.Combine(@"E:\Temp\ECOM_Accurev", copyOverPartialPath.Substring(0, copyOverPartialPath.LastIndexOf(@"\")))))
                    {
                        Directory.CreateDirectory(Path.Combine(@"E:\Temp\ECOM_Accurev", copyOverPartialPath.Substring(0, copyOverPartialPath.LastIndexOf(@"\"))));
                    }

                    File.Copy(fileName, Path.Combine(@"E:\Temp\ECOM_Accurev", fileName.Substring(8)),true);
                    fileStatus.AppendLine(fileName);
                }                
                else if (Directory.Exists(fileName))
                {
                    foreach (string f in Directory.GetFiles(fileName))
                    {
                        if (!Directory.Exists(Path.Combine(@"E:\Temp\ECOM_Accurev", copyOverPartialPath)))
                        {
                            Directory.CreateDirectory(Path.Combine(@"E:\Temp\ECOM_Accurev", copyOverPartialPath));
                        }

                        File.Copy(f, Path.Combine(@"E:\Temp\ECOM_Accurev", f.Substring(8)));
                        directoryStatus.AppendLine(f);
                    }
                }
            }

            txtStatus.Text = $"File Status : \n {fileStatus.ToString()} \n\n Directory Status: \n{directoryStatus.ToString()}" ;
            MessageBox.Show("Completed");

        }
    }
}
