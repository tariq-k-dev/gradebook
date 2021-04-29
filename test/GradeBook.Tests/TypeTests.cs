using System;
using System.Collections.Generic;
using Gradebook;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests
{
    public class TypeTest

    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Snoopy";
            string nameUpper = MakeUpperCase(name);

            Assert.Equal("Snoopy", name);
            Assert.Equal("SNOOPY", nameUpper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            Book book1 = GetBook("Book 1");

            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetNameByRef(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            Book book1 = GetBook("Book 1");

            GetBookSetNameByRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            Book book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void GetBookCreatesNewObject()
        {
            Book book1 = GetBook("Book 1");
            Book book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void VariablesCanReferenceSameObject()
        {
            Book book1 = GetBook("Book 1");
            Book book2 = book1;

            // Verify by name
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);


            // Verify using the same method in the Assert class
            Assert.Same(book1, book2);

            // This is equivalent to using the same method
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
    }
}
