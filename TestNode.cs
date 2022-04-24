using Godot;
using Newtonsoft.Json;

namespace Test
{
    public class TestNode : ColorRect
    {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            JsonSerializer serializer;
            Color = Colors.Aqua;
            ResourceDirectory.Open("res://");
            GD.Print("Updating glyph config");
            CopyFile("res://glyphs.json", "user://glyphs.json");
            GD.Print("Loading glyph texture configuration");
            GlyphTextureConfiguration = GlyphTextureConfiguration.FromFile("user://glyphs.json");
            GD.Print("Glyph config updated");
        }
        public static readonly Directory ResourceDirectory = new Directory();
        public static GlyphTextureConfiguration GlyphTextureConfiguration;


        public static void CopyFile(string resourcePath, string userPath)
        {
            if (ResourceDirectory.FileExists(userPath)) return;
            GD.Print($"{userPath} not exist, copying from {resourcePath}");
            ResourceDirectory.Copy(resourcePath, userPath);
        }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    }
}
