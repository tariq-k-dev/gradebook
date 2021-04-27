using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        private List<double> grades;
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public Book(string name, List<double> grades)
        {
            this.name = name;
            this.grades = grades;
        }

        public string getname()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public List<double> GetGrades()
        {
            return grades;
        }

        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("\nValid grade range is between 0 and 100!");
                Console.WriteLine($"Invalid grade that was entered: {grade}");
            }
            else
            {
                grades.Add(Math.Round(grade, 1));
            }
        }

        public void RemoveGrade(double grade)
        {
            if (grades.Contains(grade))
            {
                grades.Remove(grade);
            }
            else
            {
                Console.WriteLine($"{grade} not found in grade book.");
            }
        }

        public double LowestGrade()
        {
            if (grades.Count > 0)
            {
                double lowestGrade = double.MaxValue;

                foreach (double grade in grades)
                {
                    lowestGrade = Math.Min(grade, lowestGrade);
                }

                return lowestGrade;
            }
            else
            {
                return 0;
            }
        }

        public double HighestGrade()
        {
            if (grades.Count > 0)
            {
                double highestGrade = double.MinValue;

                foreach (double grade in grades)
                {
                    highestGrade = Math.Max(grade, highestGrade);
                }

                return highestGrade;
            }
            else
            {
                return 0;
            }
        }

        public double Average()
        {
            if (grades.Count > 0)
            {
                double totalPoints = 0;
                foreach (double grade in grades)
                {
                    totalPoints += grade;
                }

                double averagePoints = totalPoints / grades.Count;

                return averagePoints;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            string gradesToString = $"\nGrades: [ ";

            int count = grades.Count;
            foreach (double grade in grades)
            {
                if (count > 1)
                {
                    gradesToString += grade + ", ";
                }
                else
                {
                    gradesToString += grade;
                }
                count--;
            }
            gradesToString += " ]";

            return gradesToString;
        }

        public Statistics GetStatistics()
        {
            Statistics result = new Statistics();

            if (grades.Count == 0)
            {
                Console.WriteLine("No grades found in the Grade Book.");
            }
            else
            {
                double averageGrade = 0;

                foreach (double grade in grades)
                {
                    if (grade < result.LowGrade)
                    {
                        result.LowGrade = Math.Min(grade, result.LowGrade);
                    }

                    if (grade > result.HighGrade)
                    {
                        result.HighGrade = Math.Max(grade, result.HighGrade);
                    }

                    averageGrade += grade;
                }

                averageGrade /= grades.Count;
                result.AverageGrade = averageGrade;
            }

            return result;
        }

        public void ShowStatistics()
        {
            if (grades.Count <= 0)
            {
                Console.WriteLine($"No grades found in {name}'s Gradebook.");
            }
            else
            {
                char charToRepeat = '=';
                string repeatedString = new string(charToRepeat, 30);
                Console.WriteLine($"\n{repeatedString}");
                Console.WriteLine($"Gradebook for {name}");
                Console.WriteLine(ToString());
                Console.WriteLine($"Lowest Grade: {GetStatistics().LowGrade:N1}");
                Console.WriteLine($"Highest Grade: {GetStatistics().HighGrade:N1}");
                Console.WriteLine($"Average Grade: {GetStatistics().AverageGrade:N1}");
                Console.WriteLine($"{repeatedString}\n");
            }
        }
    }
}