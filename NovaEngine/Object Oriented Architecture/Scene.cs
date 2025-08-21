namespace NovaEngine {
    public class Scene {
        public List<GameObject> gameObjects = new List<GameObject>();
        public Camera mainCamera = null!;


        public void AddGameObject(GameObject gameObject) {
            gameObjects.Add(gameObject);
        }


        public void RemoveGameObject(GameObject gameObject) {
            gameObjects.Remove(gameObject);
        }


        public void Start() {
            foreach (GameObject gameObjects in gameObjects) {
                gameObjects.Start();
            }
        }


        public void Update(double deltaTime) {
            foreach (GameObject gameObject in gameObjects) {
                gameObject.Update(deltaTime);
            }
        }


        public void Dispose() {
            foreach (GameObject gameObject in gameObjects) {
                gameObject.Dispose();
            }
        }
    }
}
