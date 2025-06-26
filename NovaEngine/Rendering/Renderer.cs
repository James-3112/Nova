using System.Numerics;
using Silk.NET.Windowing;


namespace NovaEngine {
    public abstract class Renderer {
        public abstract void Initialize(IWindow window);
        public abstract void Dispose();

        public abstract void Clear(float r, float g, float b, float a);
        public abstract void ResizeWindow(int width, int height);
        public abstract void DrawMesh(Mesh mesh, Shader shader, Texture texture, Matrix4x4 modelMatrix);
    }
}
