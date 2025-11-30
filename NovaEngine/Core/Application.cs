using Silk.NET.Maths;


namespace NovaEngine {
    public static class Application {
        // TODO - Could change this to be able to use multiple windows
        public static Window window = null!;

        private static Dictionary<Type, Layer> layers = new();
        private static List<Func<Layer>> layerConstructors = new List<Func<Layer>>();


        // Starts the application
        public static void Start() {
            // Creates the window for the application and adds all the callbacks for the window
            window = new Window();
            window.silkWindow.Load += WindowLoad;
            window.silkWindow.Update += WindowUpdate;
            window.silkWindow.FramebufferResize += WindowResize;
            window.silkWindow.Closing += WindowClose;

            // Starts the window
            window.Start();
        }


        // Quits the application
        public static void Quit() {
            window.Close();
        }


        #region Layers
        // Adds a layer to the layer constructors list to be initialized once the window has loaded
        public static void AddLayer<T>(params object[] dependencies) where T : Layer {
            Type layerType = typeof(T);

            if (!typeof(Layer).IsAssignableFrom(layerType)) {
                Debug.LogError($"Type must be a subclass of Layer. Got: {layerType.FullName}");
            }

            layerConstructors.Add(() => CreateLayerInstance(layerType, dependencies));
        }

        // Create the constructor for the layer to be initialized once the window has loaded
        private static Layer CreateLayerInstance(Type layerType, object[] dependencies) {
            List<object> availableDeps = dependencies.ToList();

            var constructor = layerType.GetConstructors().FirstOrDefault(ctor => {
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

        // Remove any layer using it's class
        public static void RemoveLayer(Layer layer) {
            if (!layers.ContainsKey(layer.GetType())) {
                Debug.LogWarn($"Tried to remove layer {layer.GetType().Name}, but it was not found");
                return;
            }

            layer.Dispose();
            layers.Remove(layer.GetType());
        }
        
        // Get any layer using it's class
        public static T GetLayer<T>() where T : Layer {
            if (layers.TryGetValue(typeof(T), out Layer? layer)) return (T)layer;

            Debug.LogWarn($"Layer of type {typeof(T).Name} not found.");
            return null!;
        }
        #endregion


        #region Window
        // Once the Window loads
        private static void WindowLoad() {
            // Construct every layer and add it to the layers list
            foreach (Func<Layer> constructor in layerConstructors) {
                Layer layer = constructor();
                layers[layer.GetType()] = layer;
            }

            // Start every layer
            foreach (Layer layer in layers.Values) {
                layer.Start();
            }
        }


        // When the window updates, update every layer and pass in the delta time
        private static void WindowUpdate(double deltaTime) {
            foreach (Layer layer in layers.Values) {
                layer.Update(deltaTime);
            }
        }
        

        // Resize the window
        private static void WindowResize(Vector2D<int> newSize) {
            
        }


        // When the window is being closed dispose of all the objects
        private static void WindowClose() {
            foreach (Layer layer in layers.Values) {
                layer.Dispose();
            }
        }
        #endregion
    }
}
