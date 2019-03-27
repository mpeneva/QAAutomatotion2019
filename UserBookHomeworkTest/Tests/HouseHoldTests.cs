
namespace UserBookHomeworkTest
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using UserBookHomeworkTest.Helpers;

    [TestFixture]
    public class HouseholdTests : BaseTest
    {
       /// <summary>
        /// Verify that the the get http invokation is successful
        /// </summary>
        /// <returns>OK</returns>        
        [Test]
        [Order(1)]
        public async Task GetHouseholdShouldReturnOK()
        {
            var response = await HttpClient.GetAsync("/households/27");
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Verify that the expected household object is returned with expected 'id' value
        /// </summary>
        /// <returns>True</returns>
        [Test]
        [Order(2)]
        public async Task GetHouseholdShoudBeProperlydReturnedById()
        {
            var response = await HttpClient.GetAsync("/households/27");
            var content = (await response.Content.ReadAsStringAsync()).Trim();
             
            //constрuct the path to the file
            var parentDirectoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var filePath = Path.Combine(parentDirectoryPath, "JSONResources", "Household.json");

            var text = (File.ReadAllText(filePath)).Trim();
            var household = Household.FromJson(text);
            var householdId = household.Id;
            content.Should().Contain(householdId.ToString());
                       
        }

        /// <summary>
        /// Verify that the expected household object is returned with expected 'name' value
        /// </summary>
        /// <returns>True</returns>
        [Test]
        [Order(3)]
        public async Task GetHouseholdShoudBeProperlydReturnedByName()
        {
            var response = await HttpClient.GetAsync("/households/27");
            var content = (await response.Content.ReadAsStringAsync()).Trim();

            //constрuct the path to the file
            var parentDirectoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var filePath = Path.Combine(parentDirectoryPath, "JSONResources", "Household.json");

            var text = (File.ReadAllText(filePath)).Trim();
            var household = Household.FromJson(text);
            var householdName = household.Name;
            content.Should().Contain(householdName.ToString());

        }
        /// <summary>
        /// Verify that the the post http invokation is successful
        /// </summary>
        /// <returns>OK</returns>        
        [Test]
        [Order(4)]
        public async Task PostHouseholdShouldReturnOK()
        {
            HttpContent requestBody = new StringContent(Household.NewHousehold().ToJson(), Encoding.UTF8, "application/json");
            var request = await HttpClient.PostAsync("/households", requestBody);
            request.EnsureSuccessStatusCode();

        }

        /// <summary>
        /// Verify that the the post http invokation successfuly creates a household
        /// </summary>
        /// <returns>OK</returns>        
        [Test]
        [Order(5)]
        public async Task HouseholdShouldBeCreated()
        {
            HttpContent requestBody = new StringContent(Household.NewHousehold().ToJson(), Encoding.UTF8, "application/json");
            var request = await HttpClient.PostAsync("/households", requestBody);
            request.EnsureSuccessStatusCode();
            var content = await request.Content.ReadAsStringAsync();
            var requestHouseHold = Household.FromJson(content);
            requestHouseHold.Should().BeEquivalentTo(
                Household.NewHousehold(),
                opt => opt.Excluding(household => household.Id)
                            .Excluding(household => household.UpdatedAt)
                            .Excluding(household => household.CreatedAt));
        }

        /// <summary>
        /// Verify that the the post http invokation successfuly creates a household with the expected hh name
        /// </summary>
        /// <returns>OK</returns>        
        [Test]
        [Order(6)]
        public async Task HouseholdNameShouldBeAsTheDefaultCreatedOne()
        {
            HttpContent requestBody = new StringContent(Household.NewHousehold().ToJson(), Encoding.UTF8, "application/json");
            var request = await HttpClient.PostAsync("/households", requestBody);
            
            var content = await request.Content.ReadAsStringAsync();
            var requestHouseHold = Household.FromJson(content);
            requestHouseHold.Name.Should().BeEquivalentTo(
                Household.NewHousehold().Name);
        }

    }

}
