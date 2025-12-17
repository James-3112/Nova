namespace Nova;


public class Application {
    public Stack<Layer> layerStack;
    private Window window;

    public Application() {
        Input.SetBackend(Input.Backend.Raylib);

        layerStack = new Stack<Layer>();
        layerStack.Push(new RenderLayer(RenderLayer.Backend.Raylib));

        window = Window.CreateWindow(Window.Backend.Raylib);
    }

    public void Run() {
        window.Open();

        while (window.WindowShouldClose() == false) {
            foreach (Layer layer in layerStack) {
                layer.OnUpdate();
            }
        }

        OnShutdown();
    }

    public void OnShutdown() {
        window.Close();
    }
}
