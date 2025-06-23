using System.Text.Json;
using System.IO;

namespace NovaEngine {
    public static class Json {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions {
            WriteIndented = true
        };

        public static void Save<Object>(Object obj, string filePath) {
            string json = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(filePath, json);
        }

        public static Object Load<Object>(string filePath) {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Object>(json, options)!;
        }
    }
}
