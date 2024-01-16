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

        // Test : Dictionary till JSON

        // Test : Läsa JSON-fil

        // Test : Skriva JSON-fil

    }
}
