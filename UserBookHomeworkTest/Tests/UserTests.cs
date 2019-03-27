using FluentAssertions;
using NUnit.Framework;
using System;

using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserBookHomeworkTest.Helpers;

namespace UserBookHomeworkTest
{
    [TestFixture]
    public class UserTests : BaseTest
    {
        /// <summary>
        /// Verify the return status code of the get user http invocation
        /// </summary>
        /// <returns>OK</returns>
        [Test]
        [Order(1)]
        public async Task GetUserShouldReturnOK()
        {
            var response = await HttpClient.GetAsync("/users/59");
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Verify that the expected user object is returned with expected 'firstName' value
        /// </summary>
        /// <returns>True</returns>
        [Test]
        [Order(2)]
        public async Task GetUserShoudBeProperlydReturnedByFirstName()
        {
            var response = await HttpClient.GetAsync("/users/59");
            var content = (await response.Content.ReadAsStringAsync()).Trim();

            //constрuct the path to the file
            var parentDirectoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var filePath = Path.Combine(parentDirectoryPath, "JSONResources", "User.json");

            var text = (File.ReadAllText(filePath)).Trim();
            var user = User.FromJson(text);
            var userFName = user.FirstName;
            content.Should().Contain(userFName);
        }

        /// <summary>
        /// Verify that the post http invokation successfuly creates a user with the expected user first name
        /// </summary>
        /// <returns>OK</returns>        
        [Test]
        [Order(3)]
        public async Task UserFirstNameShouldBeAsTheDefaultCreatedOne()
        {
            int numberOfUsers = 2;
            int numberBooks = 2;
            for (int i = 1; i <= numberOfUsers; i++)
            {
                for (int j = 1; j <= numberBooks; j++)
                {
                    long houseHoldId = Household.DefaultHouseHold().Id;
                    HttpContent requestBody = new StringContent(User.UserProducer("User", i, j, houseHoldId).ToJson(), Encoding.UTF8, "application/json");
                    var request = await HttpClient.PostAsync("/users", requestBody);

                    var content = await request.Content.ReadAsStringAsync();
                    var requesedtUser = User.FromJson(content);
                    userHouseHoldIdList.Add((Int32)(i+j),requesedtUser.HouseholdId);
                    userWishListIdList.Add((Int32)(i+j),requesedtUser.WishlistId);
                    requesedtUser.FirstName.Should().BeEquivalentTo(
                        User.UserProducer("User", i, j, houseHoldId).FirstName);

                }
            }
        }
    }
}

