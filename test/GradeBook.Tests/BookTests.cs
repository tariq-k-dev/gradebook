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
        public void AddGradeTest()
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
        public void LowestGradeTest()
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
        public void HighestGradeTest()
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
        public void AverageTest()
        {
            // arrange
            Book book = new Book("Linus van Pelt");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            double avgCalculated = (89.1 + 90.5 + 77.3) / 3;

            // act
            double avgGrade = book.Average();
            // output.WriteLine("Average Grade Value Test");
            output.WriteLine($"Returned Average Grade: {avgGrade}");

            // assert
            Assert.Equal(avgCalculated, avgGrade);
        }

        [Fact]
        public void StatisticsTest()
        {
            // arrange
            List<double> grades = new List<double> { 95.8, 98.9, 100 };
            Book book = new Book("Peppermint Patty", grades);

            // act
            double lowGrade = book.GetStatistics().LowGrade;
            double highGrade = book.GetStatistics().HighGrade;
            double averageGrade = book.GetStatistics().AverageGrade;

            // assert
            Assert.Equal(95.8, lowGrade, 1);
            Assert.Equal(100, highGrade, 1);
            Assert.Equal(98.2, averageGrade, 1);
        }
    }
}
