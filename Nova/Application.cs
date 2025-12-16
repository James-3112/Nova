namespace Nova;


public class Application {
    public LayerStack layerStack;
    private Window window;

    public Application() {
        Input.SetBackend(Input.Backend.Raylib);

        layerStack = new LayerStack();
        layerStack.AddLayer(new RenderLayer(RenderLayer.Backend.Raylib));

        window = Window.CreateWindow(Window.Backend.Raylib);
    }

    public void Run() {
        window.Open();

        while (window.WindowShouldClose() == false) {
            layerStack.UpdateLayers();
        }

        OnShutdown();
    }

    public void OnShutdown() {
        window.Close();
    }
}
