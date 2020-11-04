using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CreditCardProcess;
namespace CreditCardProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ProcessCreditCard pcc = new ProcessCreditCard(args[0]);
                pcc.Execute();
            }
            else
                Console.WriteLine("Please provide input file to process");
        }
    }
}
