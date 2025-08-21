namespace NovaEngine {
    public class SceneLayer : Layer {
        public Scene scene = null!;


        public override void Start() {
            SceneManager.Initialize(this);
        }


        public override void Update(double deltaTime) {
            scene.Update(deltaTime);
        }


        public override void Dispose() {
            scene.Dispose();
        }
    }
}
