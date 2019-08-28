using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class ObjectOrientatedQuestions : Form
    {
        #region
        public class People
        {
            public int BirthYear;
            public int DeathYear;
        }



        #endregion

        public ObjectOrientatedQuestions()
        {
            InitializeComponent();
        }

        private void btn_Record_Max_population_for_an_year_Click(object sender, EventArgs e)
        {
            List<People> peoples = new List<People>()
                                        {
                                            new People { BirthYear = 2000, DeathYear = 2010 },
                                            new People { BirthYear = 1975, DeathYear = 2005 },
                                            new People { BirthYear = 1975, DeathYear = 2003 },
                                            new People { BirthYear = 1803, DeathYear = 1809 },
                                            new People { BirthYear = 1750, DeathYear = 1869},
                                            new People { BirthYear = 1840, DeathYear = 1935 },
                                            new People { BirthYear = 1803, DeathYear = 1921 },
                                            new People { BirthYear = 1894, DeathYear = 1921 }
                                        };
            
            int? minBirthYear = null ; int? maxDeathYear = null;
            int year; int maxPopulation;
            this.FindMaxMinForPeople(peoples, ref minBirthYear, ref maxDeathYear);
            int[] maxNumberOfPopulation = new int[maxDeathYear.Value - minBirthYear.Value + 2];
            foreach (People p in peoples)
            {
                maxNumberOfPopulation[p.BirthYear - minBirthYear.Value] += 1;
                maxNumberOfPopulation[p.DeathYear-minBirthYear.Value + 1] += -1;
            }
            this.CalculateMaxPopulationAndItsYear(maxNumberOfPopulation, out year, out maxPopulation, minBirthYear.Value);
            MessageBox.Show($"Max population {maxPopulation.ToString()} for the year is {year.ToString()} ");

        }

        private void CalculateMaxPopulationAndItsYear(int[] maxNumberOfPopulation, out int year, out int maxPopulation, int minBirthYear)
        {
            year = -1;
            maxPopulation = -1;
            int rSum = 0;
            for(int i = 0; i < maxNumberOfPopulation.Length; i++)
            {
                rSum += maxNumberOfPopulation[i];
                if (rSum > maxPopulation)
                {
                    year = i + minBirthYear;
                    maxPopulation = rSum;
                }
            }
        }
        
       
        private void FindMaxMinForPeople(List<People> peoples, ref int? minBirthYear, ref int? maxDeathYear)
        {
            foreach(People people in peoples)
            {
                if (minBirthYear==null)
                {
                    minBirthYear = people.BirthYear;
                }
                if (maxDeathYear == null)
                {
                    maxDeathYear = people.DeathYear;
                }

                if (minBirthYear > people.BirthYear)
                {
                    minBirthYear = people.BirthYear;
                }

                if (maxDeathYear < people.DeathYear)
                {
                    maxDeathYear = people.DeathYear;
                }
            }

        }

        private void btn_Abstract_Class_Click(object sender, EventArgs e)
        {

        }

        private void btn_Calculate_Tax_Bracket_Click(object sender, EventArgs e)
        {
            decimal salary = 15000.00M;
            decimal taxAmount = 0.00M;
            List<TaxBracket> taxBrackets = this.GetTaxBrackets();

            foreach(TaxBracket tb in taxBrackets)
            {
                if (salary > tb.MinBracket)
                {
                    if (salary < tb.MaxBracket)
                    {
                        taxAmount += (salary - tb.MinBracket) * tb.Rate;
                    }
                    else
                    {
                        taxAmount += tb.Rate * (tb.MaxBracket - tb.MinBracket);
                    }
                }
            }

            MessageBox.Show($"Tax amount is {taxAmount.ToString()}  for the salary {salary.ToString()}");


        }

        private List<TaxBracket> GetTaxBrackets()
        {
            List<TaxBracket> taxBrackets = new List<TaxBracket>();
            taxBrackets.Add(new TaxBracket() { MinBracket = 0, MaxBracket = 10000, Rate = 0.10M });
            taxBrackets.Add(new TaxBracket() { MinBracket = 10000, MaxBracket = 20000, Rate = 0.20M });
            taxBrackets.Add(new TaxBracket() { MinBracket = 20000, MaxBracket = 100000000000, Rate = 0.30M });
            return taxBrackets;

        }

        class TaxBracket
        {
            public decimal MinBracket { get; set; }
            public decimal MaxBracket { get; set; }
            public decimal Rate { get; set; }

        }
    }
}
