using Silk.NET.OpenGL;
using StbImageSharp;


namespace Nova.Graphics {
    public unsafe class Texture: IDisposable {
        private GL gl;
        private uint handle;

        public Texture(GL gl, string path) {
            this.gl = gl;
            handle = gl.GenTexture();
            Bind();

            // Import the image
            ImageResult image;
            try {
                image = ImageResult.FromMemory(File.ReadAllBytes(path), ColorComponents.RedGreenBlueAlpha);
            } catch (Exception ex) {
                throw new Exception($"Failed to load image from path: {path}", ex);
            }

            // Define a pointer to the image data
            fixed (byte* ptr = image.Data) {
                // Here we use "result.Width" and "result.Height" to tell OpenGL about how big our texture is.
                gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba, (uint)image.Width, (uint)image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, ptr);
            }

            // Configure the texture parameters
            gl.TexParameter(GLEnum.Texture2D, GLEnum.TextureWrapS, (int)TextureWrapMode.Repeat);
            gl.TexParameter(GLEnum.Texture2D, GLEnum.TextureWrapT, (int)TextureWrapMode.Repeat);
            gl.TexParameter(GLEnum.Texture2D, GLEnum.TextureMinFilter, (int)TextureMinFilter.NearestMipmapNearest);
            gl.TexParameter(GLEnum.Texture2D, GLEnum.TextureMagFilter, (int)TextureMagFilter.Nearest);

            gl.GenerateMipmap(TextureTarget.Texture2D);

            // Enable blending and set the blend to use the alpha to subtract
            gl.Enable(EnableCap.Blend);
            gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        public void Bind(TextureUnit textureSlot = TextureUnit.Texture0) {
            gl.ActiveTexture(textureSlot);
            gl.BindTexture(TextureTarget.Texture2D, handle);
        }

        public void Dispose() {
            gl.DeleteTexture(handle);
        }
    }
}
