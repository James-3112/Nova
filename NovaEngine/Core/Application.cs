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
    public class Application {
        public static Window window = null!;

        private List<Layer> layers = new List<Layer>();
        private List<Func<IWindow, Layer>> layerConstructors = new List<Func<IWindow, Layer>>();


        public void Start() {
            window = new Window();
            window.silkWindow.Load += OnLoad;
            window.silkWindow.Update += OnUpdate;
            window.silkWindow.FramebufferResize += OnFramebufferResize;
            window.silkWindow.Closing += OnClose;

            window.Start();
        }


        public static void Quit() {
            window.Close();
        }


        public void AddLayer(Func<IWindow, Layer> constructor) {
            layerConstructors.Add(constructor);
        }


        private void OnLoad() {
            foreach (Func<IWindow, Layer> constructor in layerConstructors) {
                Layer layer = constructor(window.silkWindow);

                layers.Add(layer);
                layer.Start();
            }
        }


        private void OnUpdate(double deltaTime) {
            foreach (Layer layer in layers) {
                layer.Update(deltaTime);
            }
        }
        

        private void OnFramebufferResize(Vector2D<int> newSize) {
            
        }


        private void OnClose() {
            foreach (Layer layer in layers) {
                layer.Dispose();
            }
        }
    }
}
