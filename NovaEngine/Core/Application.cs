using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using StbImageSharp;
using Silk.NET.OpenGL.Extensions.ImGui;
using ImGuiNET;


namespace NovaEngine {
    public static class Application {
        public static IWindow window = null!;
        public static GL gl = null!;

        private static Scene startingScene = null!;


        public static void Start(Scene scene, int width = 800, int height = 600, string title = "Nova", bool vsync = false) {
            startingScene = scene;

            WindowOptions options = WindowOptions.Default with {
                Size = new Vector2D<int>(width, height),
                Title = title,
                VSync = vsync
            };

            window = Window.Create(options);
            window.Load += OnLoad;
            window.Update += OnUpdate;
            window.Render += OnRender;
            window.FramebufferResize += OnFramebufferResize;
            window.Closing += OnClose;

            window.Run();
            window.Dispose();
        }


        public static void Quit() {
            window.Close();
        }


        private static void OnLoad() {
            IInputContext input = window.CreateInput();
            Input.Initialize(input.Keyboards.FirstOrDefault()!, input.Mice.FirstOrDefault()!);

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

            startingScene.Start();
        }


        private static void OnUpdate(double deltaTime) {
            SceneManager.UpdateScene(deltaTime);
            Input.Update();
        }


        private static void OnRender(double deltaTime) {
            gl.Clear((uint) (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));

            SceneManager.RenderScene(deltaTime);
        }


        private static void OnFramebufferResize(Vector2D<int> newSize) {
            gl.Viewport(newSize);
        }


        private static void OnClose() {
            SceneManager.UnloadScene();
        }
    }
}
