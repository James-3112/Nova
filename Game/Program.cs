using NovaEngine;


class Program {
    static void Main(string[] args) {
        Application application = new Application();

        SceneManager.LoadScene(new Scene());
        application.AddLayer<GameLayer>();
        application.AddLayer<InputLayer>();
        application.AddLayer<RendererLayer>(RendererLayer.Backend.OpenGL);

        application.Start();
    }

    private class GameLayer : Layer {
        public override void Start() {

        }

        public override void Update(double deltaTime) {
            if (Input.IsKeyPressed(KeyCode.Escape)) {
                Application.Instance.Quit();
            }
        }

        public override void Dispose() {

        }
    }
}
