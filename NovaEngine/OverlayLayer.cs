using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace NovaEngine {
    public interface IOverlayLayer {
        void Load(GL gl, IWindow window, IInputContext input);
        void Render(GL gl, double deltaTime);
        void Dispose();
    }
}
