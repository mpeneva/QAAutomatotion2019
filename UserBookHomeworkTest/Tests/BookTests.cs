using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserBookHomeworkTest.Helpers;

namespace UserBookHomeworkTest
{    
    [TestFixture]
    public class BookTests : BaseTest
    {
       

        /// <summary>
        /// Verify the return status code of the http invocation
        /// </summary>
        /// <returns>OK</returns>
        [Test]
        [Order(1)]
        public async Task GetBookShouldReturnOK()
        {
            var response = await HttpClient.GetAsync("/books/3");
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Verify that the expected book object is returned with expected 'id' value
        /// </summary>
        /// <returns>True</returns>
        [Test]
        [Order(2)]
        public async Task GetBookShoudBeProperlydReturnedById()
        {
            var response = await HttpClient.GetAsync("/books/3");
            var content = (await response.Content.ReadAsStringAsync()).Trim();

            //constрuct the path to the file
            var parentDirectoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var filePath = Path.Combine(parentDirectoryPath, "JSONResources", "Book.json");

            var text = (File.ReadAllText(filePath)).Trim();
            var book = Book.FromJson(text);
            var bookId = book.Id;
            content.Should().Contain(bookId.ToString());
        }


        /// <summary>
        /// Verify that the post http invokation successfuly creates a book with the expected book title
        /// </summary>
        /// <returns>OK</returns>        
        [Test]
        [Order(3)]
        public async Task BookTitleShouldBeAsTheDefaultCreatedOne()
        {
            int numberOfUsers = 2;
            int numberBooks = 2;
            for (int i = 1; i <= numberOfUsers; i++)
            {
                for (int j = 1; j <= numberBooks; j++)
                {
                    Book userBook = Book.BookProducer("User", (Int32)(i + j));
                    HttpContent requestBody = new StringContent(userBook.ToJson(), Encoding.UTF8, "application/json");
                    var request = await HttpClient.PostAsync("/books", requestBody);

                    var content = await request.Content.ReadAsStringAsync();
                    var requestBook = Book.FromJson(content);
                    requestedBookList.Add((Int32)(i+j),requestBook.Id);
                    requestBook.Title.Should().BeEquivalentTo(
                        Book.BookProducer("User", (Int32)(i + j)).Title);

                }
            }
        }

        /// <summary>
        /// Verify whether the book collection consist from unique books
        /// </summary>
        /// <returns>OK</returns>        
        [Test]
        [Order(5)]
        public void CheckBooksShouldBeUnique()
        {
            bool result = Book.IsBookCollectionUnique(requestedBookList);
            result.Should().Be(true);
        }

    }
}
