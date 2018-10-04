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
    }
}
