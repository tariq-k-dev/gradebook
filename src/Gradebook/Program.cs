using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<double> grades = new List<double> { 75.5, 86.4, 89.0 };
            Book book1 = new Book("Charlie Brown", grades);
            book1.AddGrade(-85);
            book1.AddGrade(120);
            book1.AddGrade(95.5);
            book1.ShowStatistics();

            Book book2 = new Book("Lucy van Pelt");
            book2.AddGrade(-1);
            book2.AddGrade(100.5);
            book2.AddGrade(95.5);
            book2.AddGrade(90);
            book2.AddGrade(82.75);
            book2.AddGrade(92);
            book2.AddGrade(65.7);
            book2.RemoveGrade(65.7);
            book2.ShowStatistics();

            grades = new List<double> { 95.8, 98.9, 100, 93.5 };
            Book book3 = new Book("Peppermint Patty", grades);
            book3.ShowStatistics();
            */

            Book newBook = new Book();
            string userInput = "";
            Console.Write("Please enter the student's name: ");
            newBook.Name = Console.ReadLine();

            while (!userInput.Equals("q"))
            {
                Console.Write("Enter a grade, 'r' to remove a grade, or 'q' to quit: ");
                userInput = Console.ReadLine();

                if (userInput.Equals("q"))
                {
                    break;
                }

                if (userInput.Equals("r"))
                {
                    Console.Write("Enter a grade value to be removed: ");
                    userInput = Console.ReadLine();

                    try
                    {
                        double grade = double.Parse(userInput);
                        newBook.RemoveGrade(grade);
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("\nNot a valid grade");
                    }
                }
                else
                {
                    try
                    {
                        double grade = double.Parse(userInput);
                        newBook.AddGrade(Math.Round(grade, 1));
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("\nNot a valid grade");
                    }
                }
            }

            newBook.ShowStatistics();
        }
    }
}
