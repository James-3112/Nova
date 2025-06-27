using System.Numerics;
using Silk.NET.Windowing;


namespace NovaEngine {
    public abstract class Renderer {
        public abstract void Clear();

        public abstract void ResizeWindow(int width, int height);
        public abstract void ResizeWindow(Vector2 size);

        public abstract void DrawMesh(Mesh mesh, Shader shader, Texture texture, Matrix4x4 modelMatrix);

        public abstract MeshBackend CreateMeshBackend(float[] vertices, uint[] indices);
        public abstract ShaderBackend CreateShaderBackend(string vertexPath, string fragmentPath);
        public abstract TextureBackend CreateTextureBackend(string path);
    }
}
