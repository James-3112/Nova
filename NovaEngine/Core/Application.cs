using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Numerics;

using System.Drawing;

using StbImageSharp;
using Silk.NET.OpenGL.Extensions.ImGui;
using ImGuiNET;
using System.Reflection;


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


        public void AddLayer<T>(params object[] dependencies) where T : Layer {
            Type layerType = typeof(T);

            if (!typeof(Layer).IsAssignableFrom(layerType)) {
                Debug.LogError($"Type must be a subclass of Layer. Got: {layerType.FullName}");
            }

            layerConstructors.Add(_ => {
                List<object> availableDeps = dependencies.ToList();
                availableDeps.Add(window.silkWindow);

                var constructor = layerType.GetConstructors()
                    .FirstOrDefault(ctor => {
                        var parameters = ctor.GetParameters();
                        return parameters.All(param => availableDeps.Any(dep => param.ParameterType.IsInstanceOfType(dep)));
                    });

                if (constructor != null) {
                    var args = constructor.GetParameters()
                        .Select(param => availableDeps.First(dep => param.ParameterType.IsInstanceOfType(dep)))
                        .ToArray();
                    return (Layer)constructor.Invoke(args);
                }

                Debug.LogError($"No suitable constructor found for {layerType.Name}");
                return null!;
            });
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
