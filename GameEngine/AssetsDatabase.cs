namespace GameEngine;
public class AssetsDatabase
{
    public const string FOLDER_PATH = "Assets";
    private Dictionary<string, Texture> _textures = [];

    public void Load()
    {
        var files = Directory.GetFiles(FOLDER_PATH);
        var textures = files.Where(f => Path.GetExtension(f) == ".png");
        _textures = textures.ToDictionary(f => Path.GetFileNameWithoutExtension(f), Texture.LoadFromFile);
    }

    public Texture? GetTexture(string name)
    {
        if(_textures.TryGetValue(name, out var texture))
        {
            return texture;
        }

        return null;
    }
}
