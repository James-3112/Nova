namespace NovaEngine {
    public class Scene {
        public static Scene currentScene = null!;

        public List<GameObject> gameObjects = new List<GameObject>();
        public Camera camera = null!;


        public void AddGameObject(GameObject gameObject) {
            if (!gameObjects.Contains(gameObject))
                gameObjects.Add(gameObject);
        }


        public static void AddGameObject(Scene scene, GameObject gameObject) {
            if (!scene.gameObjects.Contains(gameObject))
                scene.gameObjects.Add(gameObject);
        }


        public void RemoveGameObject(GameObject gameObject) {
            gameObjects.Remove(gameObject);
        }


        public static void RemoveGameObject(Scene scene, GameObject gameObject) {
            scene.gameObjects.Remove(gameObject);
        }


        public static void SetMainCamera(Camera camera) {
            currentScene.camera = camera;
        }


        public static void Load(Scene scene) {
            currentScene = scene;
        }


        public static void Start() {
            foreach (GameObject gameObjects in currentScene.gameObjects) {
                gameObjects.Start();
            }
        }


        public static void Update(double deltaTime) {
            if (currentScene == null) return;

            foreach (GameObject gameObject in currentScene.gameObjects) {
                gameObject.Update(deltaTime);
            }
        }


        public static void Render(double deltaTime) {
            foreach (GameObject gameObject in currentScene.gameObjects) {
                gameObject.Render(deltaTime);
            }
        }


        public static void Unload() {
            foreach (GameObject gameObject in currentScene.gameObjects) {
                gameObject.Dispose();
            }

            currentScene = null!;
        }
    }
}
