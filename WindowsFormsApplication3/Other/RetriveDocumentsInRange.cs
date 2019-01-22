using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication3.Other
{
    public partial class RetriveDocumentsInRange : Form
    {
        public RetriveDocumentsInRange()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGetDocuments_Click(object sender, EventArgs e)
        {
            string startDate = textBox1.Text;
            string endDate = textBox2.Text;

            Regex regex = new Regex(@"\d+");
            
            

            


            


        }

        private List<Document> GetDocuments(string date)
        {
            var documents = from doc in XElement.Load(@"C:\Personal\Study\WindowsFormsApplication3\Data\Documents.xml").Descendants()
                            where doc.Attribute("documentDate").Value.Contains(date)
                            select new Document() { Name = doc.Attribute("name").Value, DocumentDate = doc.Attribute("documentDate").Value };                            

            return documents.ToList<Document>();            
        }
        

                
    }

    class Document
    {
        public string Name { get; set; }
        public string DocumentDate { get; set; }
    }
}
