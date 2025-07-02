namespace NovaEngine {
    public class SceneLayer : Layer {
        public Scene scene;


        public SceneLayer(Scene scene) {
            this.scene = scene;
        }


        public override void Start() {
            scene.Start();
        }


        public override void Update(double deltaTime) {
            scene.Update(deltaTime);
            scene.Render(deltaTime);
        }


        public override void Dispose() {
            scene.Unload();
        }
    }
}
