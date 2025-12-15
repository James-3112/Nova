namespace Nova;


public class LayerStack {
    private List<Layer> layers = new List<Layer>();

    public void AddLayer(Layer layer) {
        layers.Add(layer);
        layer.OnAttach();
    }

    public void RemoveLayer(Layer layer) {
        layers.Remove(layer);
    }

    public void Update() {
        foreach (Layer layer in layers) {
            layer.OnUpdate();
        }
    }
}
