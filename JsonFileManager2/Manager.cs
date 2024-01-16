using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonFileManager2
{
    public class Manager
    {
        // JSON till Dictionary

        // Dictionary till JSON
        public string CreateJsonFromDict(Dictionary<string, object> dict)
        {
            // Guard clause
            if (dict == null) { throw new ArgumentNullException(); }
            else if (!dict.Any()) { throw new ArgumentException(); }
            else if (dict.ContainsValue(null)) { throw new NullReferenceException(); }
            return JsonConvert.SerializeObject(dict);
        }


        // Läsa JSON-fil

        // Skriva JSON-fil
        public void WriteJsonFile(string json, string fileName)
        {
            // Guard clause
            if (IsValidJson(json))
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                File.WriteAllText(filePath, json);
            }
        }

        /// <summary>
        /// Validates a string as JSON.
        /// </summary>
        /// <param name="stringToValidate"></param>
        /// <returns>Returns true if the input string is correct JSON, otherwise this method throws a JsonReaderExeption.</returns>
        /// <exception cref="JsonReaderException"></exception>
        private bool IsValidJson(string stringToValidate)
        {
            JToken.Parse(stringToValidate);
            return true;
        }
    }
}