using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using StbImageSharp;

using Nova.Graphics;
using Nova.Utilities;


namespace Nova.Core {
    public class GameWindow {
        // public IWindow window;

        // private IKeyboard keyboard = null!;
        // private IMouse mouse = null!;

        // private GL gl = null!;


        // public GameWindow(Vector2D<int> size, string title = "Nova") {
        //     WindowOptions options = WindowOptions.Default with {
        //         Size = size,
        //         Title = title
        //     };

        //     window = Window.Create(options);

        //     window.Load += OnLoad;
        //     window.Update += OnUpdate;
        //     window.Render += OnRender;
        //     window.FramebufferResize += OnFramebufferResize;
        //     window.Closing += OnClose;
        // }


        // public GameWindow(WindowOptions options) {
        //     window = Window.Create(options);

        //     window.Load += OnLoad;
        //     window.Update += OnUpdate;
        //     window.Render += OnRender;
        //     window.FramebufferResize += OnFramebufferResize;
        //     window.Closing += OnClose;
        // }


        // public void Run() {
        //     window.Run();
        //     window.Dispose();
        // }


        // public void Close() {
        //     window.Close();
        // }


        // private void OnLoad() {
        //     // Input Init
        //     IInputContext input = window.CreateInput();

        //     keyboard = input.Keyboards.FirstOrDefault()!;
        //     mouse = input.Mice.FirstOrDefault()!;

        //     mouse.Cursor.CursorMode = CursorMode.Raw;
        //     mouse.MouseMove += OnMouseMove;

        //     // OpenGL Init
        //     gl = window.CreateOpenGL();
        //     gl.ClearColor(Color.CornflowerBlue);
        // }


        // private void OnUpdate(double deltaTime) {
        //     throw new NotImplementedException();
        // }


        // private void OnRender(double deltaTime) {
        //     throw new NotImplementedException();
        // }


        // private void OnFramebufferResize(Vector2D<int> newSize) {
        //     gl.Viewport(newSize);
        // }


        // private void OnClose() {
        //     throw new NotImplementedException();
        // }
    }
}
