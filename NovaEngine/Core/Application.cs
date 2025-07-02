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
        public static Application Instance { get; private set; } = null!;

        private Window window = null!;

        private List<Layer> layers = new List<Layer>();
        private List<Func<IWindow, Layer>> layerConstructors = new List<Func<IWindow, Layer>>();


        public Application() {
            Instance = this;
        }


        public void Start() {
            window = new Window();
            window.silkWindow.Load += Load;
            window.silkWindow.Update += Update;
            window.silkWindow.FramebufferResize += FramebufferResize;
            window.silkWindow.Closing += Close;

            window.Start();
        }


        public void Quit() {
            window.Close();
        }


        public void AddLayer<T>(params object[] dependencies) where T : Layer {
            Type layerType = typeof(T);

            if (!typeof(Layer).IsAssignableFrom(layerType)) {
                Debug.LogError($"Type must be a subclass of Layer. Got: {layerType.FullName}");
            }

            layerConstructors.Add(_ => CreateLayerInstance(layerType, dependencies));
        }


        public Layer AddAndStartLayer<T>(params object[] dependencies) where T : Layer {
            Type layerType = typeof(T);

            if (!typeof(Layer).IsAssignableFrom(layerType)) {
                Debug.LogError($"Type must be a subclass of Layer. Got: {layerType.FullName}");
            }

            Layer layer = CreateLayerInstance(layerType, dependencies);
            layers.Add(layer);
            layer.Start();

            return layer;
        }


        private Layer CreateLayerInstance(Type layerType, object[] dependencies) {
            List<object> availableDeps = dependencies.ToList();
            
            if (window != null && window.silkWindow != null) {
                availableDeps.Add(window.silkWindow);
            }

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
        }


        public void RemoveLayer(Layer layer) {
            if (!layers.Contains(layer)) {
                Debug.LogWarn($"Tried to remove layer {layer.GetType().Name}, but it was not found.");
                return;
            }

            layer.Dispose();
            layers.Remove(layer);
        }


        private void Load() {
            foreach (Func<IWindow, Layer> constructor in layerConstructors) {
                Layer layer = constructor(window.silkWindow);
                layers.Add(layer);
                layer.Start();
            }
        }


        private void Update(double deltaTime) {
            foreach (Layer layer in layers) {
                layer.Update(deltaTime);
            }
        }
        

        private void FramebufferResize(Vector2D<int> newSize) {
            
        }


        private void Close() {
            foreach (Layer layer in layers) {
                layer.Dispose();
            }
        }
    }
}
