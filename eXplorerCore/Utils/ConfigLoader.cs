using System.Text.Json;

namespace eXplorer.Utils
{
    internal class ConfigLoader
    {
        public static Config? LoadConfig()
        {
            try
            {
                string jsonConfig = File.ReadAllText("config.json");

                // Attempt to deserialize the JSON.
                var config = JsonSerializer.Deserialize<Config>(jsonConfig);

                return config;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Configuration file (config.json) not found.");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error parsing JSON configuration: " + ex.Message);
            }
            return null;
        }
    }
}
