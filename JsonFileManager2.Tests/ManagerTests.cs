using FluentAssertions;
using Newtonsoft.Json;

namespace JsonFileManager2.Tests
{
    public class ManagerTests
    {
        // Test : JSON till Dictionary
        [Fact]
        public void CreateJsonFromDict_ShouldReturnJson()
        {
            // Given
            Dictionary<string, object> dict = new()
            {
                {"Name", "Gandalf" },
                {"Age","3000"},
                {"Profession","Wizard"}
            };
            Manager manager = new();

            // When
            string expectedJson = JsonConvert.SerializeObject(dict);
            string returnedJson = manager.CreateJsonFromDict(dict);

            // Then
            returnedJson.Should().NotBeNull();
            returnedJson.Should().BeEquivalentTo(expectedJson);
        }

        [Fact]
        public void CreateJsonFromDict_EmptyDict_ShouldThrowArgumentExcetion()
        {
            // Given
            Dictionary<string, object> dict = new();
            Manager manager = new();

            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<ArgumentException>();

        }

        [Fact]
        public void CreateJsonFromDict_Null_ShouldThrowArgumentNullExcetion()
        {
            // Given
            Dictionary<string, object>? dict = null;
            Manager manager = new();

            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateJsonFromDict_NullValue_ShouldThrowNullReferensExeption()
        {
            // Given
            Dictionary<string, object> dict = new()
            {
                {"Name", null },
                {"Age","3000"},
                {"Profession","Wizard"}
            };
            Manager manager = new();

            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<NullReferenceException>();
        }

        // Test : Dictionary till JSON

        // Test : Läsa JSON-fil

        // Test : Skriva JSON-fil
        [Fact]
        public void WriteJsonFile_ValidJson_ShouldWriteJsonFile()
        {
            // Given
            object obj = new { Name = "Sam Gamgee", Age = 30, Profession = "Gardener" };
            string json = JsonConvert.SerializeObject(obj);
            string fileName = "test.json";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            Manager manager = new();

            // When
            manager.WriteJsonFile(json, fileName);

            // Then
            string fileContent = File.ReadAllText(filePath);
            fileContent.Should().BeEquivalentTo(json);
        }

        [Fact]
        public void WriteJsonFile_InvalidJson_ShouldThrowJsonReaderExeption()
        {
            // Given
            string invalidJson = "This is not json";
            string fileName = "test.json";
            Manager manager = new();

            // When
            Action test = () => manager.WriteJsonFile(invalidJson, fileName);

            // Then
            test.Should().Throw<JsonReaderException>();
        }
    }
}
