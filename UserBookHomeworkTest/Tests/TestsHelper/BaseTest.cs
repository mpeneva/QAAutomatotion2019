using System;
using System.Collections;
using System.Net.Http;
using NUnit.Framework;

namespace UserBookHomeworkTest
{
    public class BaseTest
    {
        public static Hashtable requestedBookList = new Hashtable();
        public static Hashtable userHouseHoldIdList = new Hashtable();
        public static Hashtable userWishListIdList = new Hashtable();

        public HttpClient HttpClient { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:3000");
            HttpClient.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }

        [OneTimeTearDown]
        public void ClearVariables()
        {
            requestedBookList.Clear();
            userHouseHoldIdList.Clear();
            userWishListIdList.Clear();
        }
    }
}
