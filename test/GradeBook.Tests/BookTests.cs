using System;
using System.Collections.Generic;
using Gradebook;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests
{
    public class BookTests

    {
        private readonly ITestOutputHelper output;

        public BookTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GradeBookAddsGrade()
        {
            // arrange
            Book book = new Book("Linus van Pelt");

            // act
            book.AddGrade(-89.1);
            List<double> grades = book.GetGrades();

            // assert
            Assert.DoesNotContain(-89.1, grades);
        }

        [Fact]
        public void GradeBookRemovesGrade()
        {
            // arrange
            List<double> grades = new List<double>() { 98, 94.5, 99.5, 92.8, 100 };
            Book book = new Book("Snoopy", grades);
            output.WriteLine($"Initial Grade Set: [ {string.Join(", ", grades)} ] \n\tRemoving Grade: 92.8");

            // act
            book.RemoveGrade(92.8);
            output.WriteLine($"\tFinal Grade Set:   [ {string.Join(", ", book.GetGrades())} ]");

            // assert
            Assert.DoesNotContain(92.8, book.GetGrades());
        }

        [Fact]
        public void GradeBookReturnsLowestGrade()
        {
            // arrange
            Book book = new Book("Linus van Pelt");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            double avgGrade = book.Average();
            output.WriteLine("Min Value Test");

            // assert
            Assert.Equal(77.3, book.LowestGrade());
        }

        [Fact]
        public void GradeBookReturnsHighestGrade()
        {
            // arrange
            Book book = new Book("Linus van Pelt");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            double highestGrade = book.HighestGrade();
            output.WriteLine($"Returned Highest Grade: {highestGrade}");
            // assert
            Assert.Equal(90.5, highestGrade);
        }

        [Fact]
        public void GradeBookCalculatesAverageGrade()
        {
            // arrange
            Book book = new Book("Linus van Pelt");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            double avgCalculated = Math.Round(((89.1 + 90.5 + 77.3) / 3), 1);

            // act
            double avgGrade = book.Average();
            output.WriteLine("Average Grade Test Results:");
            output.WriteLine($"\tReturned Average Grade: {avgGrade}");
            output.WriteLine($"\tAsserted Test Grade: {avgGrade}");

            // assert
            Assert.Equal(avgCalculated, avgGrade, 1);
        }

        [Fact]
        public void GradeBookReturnsStatistics()
        {
            // arrange
            List<double> grades = new List<double> { 95.8, 98.9, 100 };
            Book book = new Book("Peppermint Patty", grades);

            // act
            double lowGrade = book.GetStatistics().LowGrade;
            double highGrade = book.GetStatistics().HighGrade;
            double averageGrade = book.GetStatistics().AverageGrade;
            char letterGrade = book.GetStatistics().LetterGrade;

            // assert
            Assert.Equal(95.8, lowGrade, 1);
            Assert.Equal(100, highGrade, 1);
            Assert.Equal(98.2, averageGrade, 1);
            Assert.Equal('A', letterGrade);
        }
    }
}
