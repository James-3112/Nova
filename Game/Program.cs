using NovaEngine;


class Program {
    static void Main(string[] args) {
        Application application = new Application();
        application.AddLayer<InputLayer>();
        application.AddLayer<RendererLayer>(RendererLayer.Backend.OpenGL);

        application.Start();
    }
}
