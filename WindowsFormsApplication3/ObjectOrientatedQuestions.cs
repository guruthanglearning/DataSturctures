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

        private void btn_Garden_with_flower_type_Click(object sender, EventArgs e)
        {
            /*
                You have N gardens, labelled 1 to N.  In each garden, you want to plant one of 4 types of flowers. 
                paths[i] = [x, y] describes the existence of a bidirectional path from garden x to garden y.
                Also, there is no garden that has more than 3 paths coming into or leaving it.
                Your task is to choose a flower type for each garden such that, for any two gardens connected by a path, they have different types of flowers.
                Return any such a choice as an array answer, where answer[i] is the type of flower planted in the (i+1)-th garden.  
                The flower types are denoted 1, 2, 3, or 4.  It is guaranteed an answer exists.

                Example 1:

                Input: N = 3, paths = [[1,2],[2,3],[3,1]]
                Output: [1,2,3]
                Example 2:

                Input: N = 4, paths = [[1,2],[3,4]]
                Output: [1,2,1,2]
                Example 3:

                Input: N = 4, paths = [[1,2],[2,3],[3,4],[4,1],[1,3],[2,4]]
                Output: [1,2,3,4]

                Note:

                1 <= N <= 10000
                0 <= paths.size <= 20000
                No garden has 4 or more paths coming into or leaving it.
                It is guaranteed an answer exists.

                Complexity: 
                Time O(N) with O(paths) = O(1.5N)
                Space O(N)
             */

            List<Gardens> inputs = new List<Gardens>();

            inputs.Add(new Gardens
            {
                GardensCordinates = new List<GardensCordinates>() {
                                                                        new GardensCordinates() {X= 1, Y=2 },
                                                                        new GardensCordinates() {X= 2, Y=3 },
                                                                        new GardensCordinates() {X= 3, Y=1 }
                                                                  },
                NoOfGardens = 3
            });

            inputs.Add(new Gardens
            {
                GardensCordinates = new List<GardensCordinates>() {
                                                                        new GardensCordinates() {X= 1, Y=2 },
                                                                        new GardensCordinates() {X= 3, Y=4 }

                                                                  },
                NoOfGardens = 4
            });
            inputs.Add(new Gardens
            {
                GardensCordinates = new List<GardensCordinates>() {
                                                                        new GardensCordinates() {X= 1, Y=2 },
                                                                        new GardensCordinates() {X= 2, Y=3 },
                                                                        new GardensCordinates() {X= 3, Y=4 },
                                                                        new GardensCordinates() {X= 4, Y=1 },
                                                                        new GardensCordinates() {X= 1, Y=3 },
                                                                        new GardensCordinates() {X= 2, Y=4 }
                                                                  },
                NoOfGardens = 4
            });

            StringBuilder result = new StringBuilder();

            foreach (var input in inputs)
            {
                int[] flowerTypeForGarden = Enumerable.Repeat(1, input.NoOfGardens).ToArray<int>();
                bool proceed = true;
                int min = 0;
                int max = 0;

                while (proceed)
                {
                    proceed = false;
                    foreach (GardensCordinates cord in input.GardensCordinates)
                    {
                        min = Math.Min(cord.X, cord.Y);
                        max = Math.Max(cord.X, cord.Y);

                        if (flowerTypeForGarden[min - 1] == flowerTypeForGarden[max - 1])
                        {
                            proceed = true;
                            flowerTypeForGarden[max - 1] = flowerTypeForGarden[max - 1] == 4 ? 1 : flowerTypeForGarden[max - 1] + 1;
                        }
                    }

                }

                result.Append($"The Garden with different flower types are {string.Join(" ", flowerTypeForGarden)} \n");
            }

            MessageBox.Show(result.ToString());

        }

        public class Gardens
        {
            public List<GardensCordinates> GardensCordinates;
            public int NoOfGardens;
        }

        public class GardensCordinates
        {
            public int X;
            public int Y;

        }

        private void btn_Find_Min_Conference_room_for_the_given_meeting_times_Click(object sender, EventArgs e)
        {
            /*
                10 AM - 10:30 AM 
                10 AM - 11:00 AM
                11 AM - 12:00 PM
                1 PM - 2 PM
                1 PM - 2 PM
                1 PM - 2 PM
                Find the number of meeting rooms required to accomodate the above meetings. Given time is not ordered, so we need to sort the inputs and perform
                the operation

                Time Complexity  : Sorting O(nlogn) + Iterate the items is O(n) = O(nlogn) + O(n)   = O(nlogn) 
                Space Complexity  : O(1)
              
            */

            List<List<MeetingTime>> meetings = new List<List<MeetingTime>>();
            List<MeetingTime> meetingTimes1 = new List<MeetingTime>();
            meetingTimes1.Add(new MeetingTime() { StartDateTime = 10, EndDateTime = 10.30 });
            meetingTimes1.Add(new MeetingTime() { StartDateTime = 10, EndDateTime = 11 });
            meetingTimes1.Add(new MeetingTime() { StartDateTime = 11, EndDateTime = 12 });
            meetingTimes1.Add(new MeetingTime() { StartDateTime = 13, EndDateTime = 14 });
            meetingTimes1.Add(new MeetingTime() { StartDateTime = 13, EndDateTime = 14 });
            meetingTimes1.Add(new MeetingTime() { StartDateTime = 13, EndDateTime = 14 });
            meetings.Add(meetingTimes1);

            List<MeetingTime> meetingTimes2 = new List<MeetingTime>();
            meetingTimes2.Add(new MeetingTime() { StartDateTime = 2, EndDateTime = 5 });
            meetingTimes2.Add(new MeetingTime() { StartDateTime = 4, EndDateTime = 9 });
            meetingTimes2.Add(new MeetingTime() { StartDateTime = 9, EndDateTime = 29 });
            meetingTimes2.Add(new MeetingTime() { StartDateTime = 16, EndDateTime = 23 });
            meetingTimes2.Add(new MeetingTime() { StartDateTime = 36, EndDateTime = 45 });
            meetings.Add(meetingTimes2);
            StringBuilder result = new StringBuilder();

            foreach (var m in meetings )
            {
                result.Append($"There are {this.GetConfRoomCounter(m)} conf rooms required for the given meeting time \n {this.PrintMeetingTime(m)}  \n\n");
            }

            MessageBox.Show(result.ToString());

        }


        public class MeetingTime
        {
            public double StartDateTime;
            public double EndDateTime;
        }

        public string PrintMeetingTime(List<MeetingTime> meetings)
        {
            StringBuilder result = new StringBuilder();
            foreach(var meeting in meetings)
            {
                result.Append($"StartTime : {meeting.StartDateTime}  EndTime = {meeting.EndDateTime} \n");
            }

            return result.ToString();
        }

        public int GetConfRoomCounter(List<MeetingTime> meetingTimes)
        {
            int counterConfRoom = 0;
            if (meetingTimes.Count == 0)
            {
                return -1;
            }

            double? previousEndDateTime = null;
            foreach (var meetingTime in meetingTimes)
            {
                if (!previousEndDateTime.HasValue)
                {
                    counterConfRoom++;
                }
                else
                {
                    if (previousEndDateTime > meetingTime.StartDateTime && previousEndDateTime < meetingTime.EndDateTime)
                    {
                        counterConfRoom++;
                    }
                }
                previousEndDateTime = meetingTime.EndDateTime;
            }
            return counterConfRoom;
        }

    }
}
