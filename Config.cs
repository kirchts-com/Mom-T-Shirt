using System.IO;
using System.Text.Json;

namespace TshirtFormMockup
{
    public static class Config
    {
        public static string Language { get; private set; } = "en";

        static Config()
        {
            try
            {
                var json = File.ReadAllText("appsettings.json");
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("Language", out var lang))
                {
                    Language = lang.GetString() ?? "en";
                }
            }
            catch
            {
                Language = "en";
            }
        }
    }
}
