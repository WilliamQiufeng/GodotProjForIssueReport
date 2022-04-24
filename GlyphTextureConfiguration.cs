using System.Collections.Generic;
using System.IO;
using System.Linq;
using Godot;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using File = Godot.File;

namespace Test
{
    public class GlyphTextureConfiguration
    {
        [JsonIgnore]
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            // Formatting = Formatting.Indented,
            // Converters = new List<JsonConverter>
            // {
            //     new StringEnumConverter(new DefaultNamingStrategy())
            // }
        };
    
        [JsonIgnore]
        public static JsonSerializer Serializer = JsonSerializer.Create(SerializerSettings);

        public float StemThickness;



        public static GlyphTextureConfiguration FromFile(string path)
        {
            var file = new File();
            file.Open(path, File.ModeFlags.Read);
            var content = file.GetAsText();
            GD.Print("Content read");
            // GD.Print(content);
            var reader = new JsonTextReader(new StringReader(content));
            GD.Print("1");
            var res = Serializer.Deserialize<GlyphTextureConfiguration>(reader);
            GD.Print("2");
            reader.Close();
            GD.Print("Config deserialized");
            return res;
        }
    }
}