using OpenTK.Graphics.OpenGL;
using StbImageSharp;
using System.Drawing;

namespace GameEngine;
public class Texture(int glHandle, int width, int height)
{
    public int Width { get; init; } = width;
    public int Height { get; init; } = height;

    public readonly int Handle = glHandle;

    public static Texture LoadFromFile(string path)
    {
        StbImage.stbi_set_flip_vertically_on_load(1);
        using var stream = File.OpenRead(path);
        var image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

        GL.Enable(EnableCap.Texture2D);
        GL.Enable(EnableCap.Blend);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

        int handle = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, handle);

        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                      image.Width, image.Height, 0,
                      PixelFormat.Rgba,
                      PixelType.UnsignedByte, image.Data);

        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

        return new Texture(handle, image.Width, image.Height);
    }

    public void Draw(Point spritePosition, Size spriteSize, Point position, Size size)
    {

        float texLeft = (float)spritePosition.X / Width;
        float texRight = (float)(spritePosition.X + spriteSize.Width) / Width;
        float texBottom = (float)spritePosition.Y / Height;
        float texTop = (float)(spritePosition.Y + spriteSize.Height) / Height;

        GL.BindTexture(TextureTarget.Texture2D, Handle);

        GL.Begin(PrimitiveType.Quads);

        GL.TexCoord2(texLeft, texBottom);
        GL.Vertex2(position.X, position.Y);
        GL.TexCoord2(texRight, texBottom);
        GL.Vertex2(position.X + size.Width, position.Y);
        GL.TexCoord2(texRight, texTop);
        GL.Vertex2(position.X + size.Width, position.Y + size.Height);
        GL.TexCoord2(texLeft, texTop);
        GL.Vertex2(position.X, position.Y + size.Height);

        GL.End();
    }
}
