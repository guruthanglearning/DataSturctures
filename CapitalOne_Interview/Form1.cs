using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapitalOne_Interview.BusinessObject;
using CapitalOne_Interview.DataAccess;
namespace CapitalOne_Interview
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //The below commented code is the calling code for API for some reason I could not able to call and getting the below error
            //Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host
            //I decide to get the data from https://2016.api.levelmoney.com/ and store them locally in json file and query the data

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://2016.api.levelmoney.com/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            //HttpResponseMessage response = client.GetAsync("/api/v2/core/get-all-transactions/?uid=1110590645&token=2B5075227E074DECE543EB29AA60A9D4&api-toke=AppTokenForInterview").Result;
            //TransactionCollection transactions = await response.Content.ReadAsAsync<TransactionCollection>();


            TransactionCollection transactions = null;
            //Loading json data to transaction collection 
            using (StreamReader stream = new StreamReader(Path.Combine(Application.StartupPath, "TransactionData.json")))
            {
                transactions = (TransactionCollection)JsonConvert.DeserializeObject(stream.ReadToEnd(), typeof(TransactionCollection));
            }

            Process process = new Process();
            if (transactions != null && transactions.Transactions != null && transactions.Transactions.Count > 0)
            {
                richTextBox1.Text = process.CalculateTransactions(transactions);
                richTextBox1.Text += process.GetCreditCardTransactions(transactions);
            }                 
            else
            {
                richTextBox1.Text = "No Records to process";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
