using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CreditCardProcessor.DataAccessLayer;
using CreditCardProcessor.CreditCardProcess.Constants;

namespace CreditCardProcess
{
    public class ProcessCreditCard
    {
        private string file = string.Empty;
        Queue<string> fileDataQueue;
        CreditCardHolderAccessLayer creditCardHolderAccessLayer = null;
        CreditCardHolderLimitAccessLayer creditCardHolderLimitAccessLayer = null;

        public ProcessCreditCard(string file)
        {
            this.file = file;
            fileDataQueue = new Queue<string>();
            creditCardHolderAccessLayer = new CreditCardHolderAccessLayer();
            creditCardHolderLimitAccessLayer = new CreditCardHolderLimitAccessLayer();
        }

                
        private async Task ReadFile()
        {
            string data = string.Empty;
            try
            {
                using (StreamReader streamReader = new StreamReader(this.file))
                {
                    while (!streamReader.EndOfStream)
                    {
                        data = await streamReader.ReadLineAsync();
                        fileDataQueue.Enqueue(data);
                    }
                }
            }
            catch(FileNotFoundException )
            {
                Console.WriteLine($"Given file {file} not found");
            }
            catch (FileLoadException)
            {
                Console.WriteLine($"Error is opening file {file} ");
            }            
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured : \nMessage: {ex.Message}\nInnerException:{ex.InnerException}\nStackTrace: {ex.StackTrace}");
            }

        }

       private async Task ProcessCreditCards()
       {
            await Task.Run(() => {
                string[] data = null;

                while(fileDataQueue.Count > 0)
                {
                    data = fileDataQueue.Dequeue().Split(' ');

                    switch (data[0])
                    {
                        case Operations.ADD:
                            {

                                if (creditCardHolderAccessLayer.InsertCreditCardHolder(creditCardHolderName: data[1], creditCardNumber: data[2]) != null)
                                    creditCardHolderLimitAccessLayer.AddMoneyToCardHolderCard(creditCardHolderName: data[1], maxMoneyLimit: int.Parse(data[3].Substring(1)));
                                break;
                            }
                        case Operations.CHARGE:
                            {
                                creditCardHolderLimitAccessLayer.ChargeCardHolder(creditCardHolderName: data[1], money: int.Parse(data[2].Substring(1)));
                                break;
                            }
                        case Operations.CREDIT:
                            {
                                creditCardHolderLimitAccessLayer.Credit_A_CardHolder(creditCardHolderName: data[1], money: int.Parse(data[2].Substring(1)));
                                break;
                            }
                    }                    
                }
            
            });
       }

        public void Start()
        {
            Task[] task = new Task[2];
            task[0] = Task.Run(() => this.ReadFile());
            task[1] = Task.Run(() => this.ProcessCreditCards());
            Task.WaitAll(task);

        }




    }
}
