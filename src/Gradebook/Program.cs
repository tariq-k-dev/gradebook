using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
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
            book2.ShowStatistics();

            grades = new List<double> { 95.8, 98.9, 100, 93.5 };
            Book book3 = new Book("Peppermint Patty", grades);
            book3.ShowStatistics();
        }
    }
}
