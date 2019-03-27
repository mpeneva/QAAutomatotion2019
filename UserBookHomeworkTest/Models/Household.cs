namespace UserBookHomeworkTest
{
    using System;
    using Newtonsoft.Json;
    using UserBookHomeworkTest.Models;

    public partial class Household : UserBookHomeworkTestBaseClass
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        public static Household FromJson(string json) => JsonConvert.DeserializeObject<Household>(json, UserBookHomeworkTest.Helpers.Converter.Settings);

        public static Household DefaultHouseHold()
        {
            return new Household
            {
                Id = 27,
                Name = "Pernik",
                CreatedAt = new DateTimeOffset(new DateTime(2017,02,22)),
                UpdatedAt = new DateTimeOffset(new DateTime(2018,02,26))
            };
        }

        public static Household NewHousehold()
        {
            return new Household
            {
                Name = "Karlovo"
            };
        }
    }
}

