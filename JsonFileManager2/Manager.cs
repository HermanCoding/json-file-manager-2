using Newtonsoft.Json;

namespace JsonFileManager2
{
    public class Manager
    {
        // JSON till Dictionary

        // Dictionary till JSON
        public string CreateJsonFromDict(Dictionary<string, object> dict)
        {
            if (!dict.Any())
            {
                throw new ArgumentException();
            }
            return JsonConvert.SerializeObject(dict);
        }
        // Läsa JSON-fil

        // Skriva JSON-fil
    }
}
