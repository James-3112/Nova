using Silk.NET.Windowing;


namespace NovaEngine {
    public class LayerFactory {
        private readonly List<Func<IWindow, Layer>> layerConstructors = new();

        public void Add(Func<IWindow, Layer> factory) {
            layerConstructors.Add(factory);
        }

        public void Remove(Func<IWindow, Layer> factory) {
            layerConstructors.Remove(factory);
        }

        public IEnumerable<Layer> BuildAll(IWindow window) {
            foreach (var factory in layerConstructors) {
                yield return factory(window);
            }
        }

        public void Clear() {
            layerConstructors.Clear();
        }
    }
}
