using Newtonsoft.Json;
using UserBookHomeworkTest.Models;

namespace UserBookHomeworkTest.Helpers
{
    public static class Serializer 
    {
        public static string ToJson(this UserBookHomeworkTestBaseClass self) => JsonConvert.SerializeObject(self, UserBookHomeworkTest.Helpers.Converter.Settings);
    }
}
