using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        private List<double> grades = new List<double>();
        public string Name;

        public Book() { }

        public Book(string name)
        {
            Name = name;
        }

        public Book(string name, List<double> grades)
        {
            Name = name;
            this.grades = grades;
        }

        public string Getname()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public List<double> GetGrades()
        {
            return grades;
        }

        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("\nValid grades are from 0 to 100");
            }
            else
            {
                grades.Add(Math.Round(grade, 1));
                Console.WriteLine($"\nAddied Grade {grade} for Student {Name}: [ {string.Join(", ", GetGrades())} ]");
            }
        }

        public void RemoveGrade(double grade)
        {
            if (grades.Contains(grade))
            {
                grades.Remove(grade);
                Console.WriteLine($"\nRemoved Grade {grade} for Student {Name}: [ {string.Join(", ", GetGrades())} ]");
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

                return Math.Round(averagePoints, 1);
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

                /*
                // using a for loop to calculate the average grade
                for (int i = 0; i < grades.Count; i++)
                {
                    if (grades[i] < result.LowGrade)
                    {
                        result.LowGrade = Math.Min(grades[i], result.LowGrade);
                    }

                    if (grades[i] > result.HighGrade)
                    {
                        result.HighGrade = Math.Max(grades[i], result.HighGrade);
                    }

                    averageGrade += grades[i];
                    i += 1;
                }
                */

                /*
                // using a while loop to calculate the average grade
                int i = 0;
                while (i < grades.Count)
                {
                    if (grades[i] < result.LowGrade)
                    {
                        result.LowGrade = Math.Min(grades[i], result.LowGrade);
                    }

                    if (grades[i] > result.HighGrade)
                    {
                        result.HighGrade = Math.Max(grades[i], result.HighGrade);
                    }

                    averageGrade += grades[i];
                    i += 1;
                }
                */

                /*
                // using do/while to calculate the average grade
                if (grades.Count > 0)
                {
                    int i = 0;
                    do
                    {
                        if (grades[i] < result.LowGrade)
                        {
                            result.LowGrade = Math.Min(grades[i], result.LowGrade);
                        }

                        if (grades[i] > result.HighGrade)
                        {
                            result.HighGrade = Math.Max(grades[i], result.HighGrade);
                        }

                        averageGrade += grades[i];
                        i += 1;
                    } while (i < grades.Count);
                }
                */

                averageGrade /= grades.Count;
                result.AverageGrade = averageGrade;
                result.LetterGrade = AddLetterGrade(averageGrade);
            }

            return result;
        }

        public char AddLetterGrade(double averageGrade)
        {
            char letterGrade = default;

            switch (averageGrade)
            {
                case double grade when grade >= 90:
                    letterGrade = 'A';
                    break;
                case double grade when grade >= 80:
                    letterGrade = 'B';
                    break;
                case double grade when grade >= 70:
                    letterGrade = 'C';
                    break;
                case double grade when grade >= 60:
                    letterGrade = 'D';
                    break;
                case double grade when grade < 60:
                    letterGrade = 'F';
                    break;
                default:
                    letterGrade = 'F';
                    break;
            }

            return letterGrade;
        }

        public void ShowStatistics()
        {
            if (grades.Count <= 0)
            {
                Console.WriteLine($"No grades found in {Name}'s Gradebook.");
            }
            else
            {
                char charToRepeat = '=';
                string gradesOutput = $"     Grades: [ {string.Join(", ", GetGrades())} ]";
                string repeatedString = new string(charToRepeat, (gradesOutput.Length + 5));
                Console.WriteLine($"\n{repeatedString}");
                Console.WriteLine($"     Gradebook for {Name}");
                Console.WriteLine($"{repeatedString}");
                Console.WriteLine(gradesOutput);
                Console.WriteLine($"     Lowest Grade: {GetStatistics().LowGrade:N1}");
                Console.WriteLine($"     Highest Grade: {GetStatistics().HighGrade:N1}");
                Console.WriteLine($"     Average Grade: {GetStatistics().AverageGrade:N1}");
                Console.WriteLine($"     Letter Grade: {GetStatistics().LetterGrade}");
                Console.WriteLine($"{repeatedString}\n");
            }
        }
    }
}
