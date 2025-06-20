using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using StbImageSharp;

using Nova.Graphics;
using Nova.Utilities;
using Nova.ObjectOrientedArchitecture;


namespace Nova.Core {
    public class Engine {
        public static IWindow window = null!;

        public static GL gl = null!;

        public event Action startEvent = null!;

        public delegate void UpdateEvent(double deltaTime);
        public event UpdateEvent updateEvent = null!;


        public Engine(int width = 800, int height = 600, string title = "Nova", bool vsync = false) {
            WindowOptions options = WindowOptions.Default with {
                Size = new Vector2D<int>(width, height),
                Title = title,
                VSync = vsync
            };

            window = Window.Create(options);
            AddWindowEvents();
        }

        public Engine(Vector2 size, string title = "Nova", bool vsync = false) {
            WindowOptions options = WindowOptions.Default with {
                Size = new Vector2D<int>((int)size.X, (int)size.Y),
                Title = title,
                VSync = vsync
            };

            window = Window.Create(options);
            AddWindowEvents();
        }


        public Engine(WindowOptions options) {
            window = Window.Create(options);
            AddWindowEvents();
        }


        public void Run() {
            window.Run();
            window.Dispose();
        }


        public void Close() {
            window.Close();
        }


        private void AddWindowEvents() {
            window.Load += OnLoad;
            window.Update += OnUpdate;
            window.Render += OnRender;
            window.FramebufferResize += OnFramebufferResize;
            window.Closing += OnClose;
        }


        private void OnLoad() {
            IInputContext input = window.CreateInput();
            Input.Initialize(input.Keyboards.FirstOrDefault()!, input.Mice.FirstOrDefault()!);

            // mouse.Cursor.CursorMode = CursorMode.Raw;
            // mouse.MouseMove += OnMouseMove;

            // OpenGL Init
            gl = window.CreateOpenGL();
            gl.ClearColor(Color.Black);

            // Enable blending for textures and set the blend to use the alpha to subtract
            gl.Enable(EnableCap.Blend);
            gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            // Enable backface culling
            gl.Enable(GLEnum.CullFace);

            // Enable draw by depth
            gl.Enable(EnableCap.DepthTest);

            startEvent?.Invoke();
        }


        private void OnUpdate(double deltaTime) {
            updateEvent?.Invoke(deltaTime);

            Input.Update();
            Scene.Update(deltaTime);
        }


        private void OnRender(double deltaTime) {
            gl.Clear((uint) (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));

            Scene.Render(deltaTime);
        }


        private void OnFramebufferResize(Vector2D<int> newSize) {
            gl.Viewport(newSize);
        }


        private void OnClose() {
            Scene.Unload();
        }
    }
}
