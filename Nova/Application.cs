namespace Nova;


public class Application {
    public LayerStack layerStack;
    private Window window;

    public Application() {
        layerStack = new LayerStack();
        layerStack.AddLayer(new RenderLayer(RenderLayer.Backend.Raylib));

        window = Window.CreateWindow(Window.Backend.Raylib);
    }

    public void Run() {
        window.Open();

        while (window.WindowShouldClose() == false) {
            layerStack.Update();
        }

        OnShutdown();
    }

    public void OnShutdown() {
        window.Close();
    }
}
