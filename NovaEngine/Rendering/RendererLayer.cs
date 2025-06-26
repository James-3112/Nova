

namespace NovaEngine {
    public class RendererLayer : Layer {
        private Renderer renderer;

        public RendererLayer(Renderer renderer) {
            this.renderer = renderer;
            renderer.Initialize();
        }

        public override void OnUpdate(float dt) {
            foreach (GameObject gameObject in SceneManager.currentScene.gameObjects) {
                // Chech if it has a mesh render component and then render the game object

                Mesh mesh = gameObject.GetComponent<Mesh>();
                renderer.DrawMesh(mesh, mesh.shader);
            }
        }

        public override void Dispose() {
            renderer.Dispose();
        }
    }
}
