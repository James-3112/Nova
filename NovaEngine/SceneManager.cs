namespace NovaEngine {
    public static class SceneManager {
        public static Scene currentScene = null!;


        public static void AddGameObject(Scene scene, GameObject gameObject) {
            if (!scene.gameObjects.Contains(gameObject))
                scene.gameObjects.Add(gameObject);
        }


        public static void RemoveGameObject(Scene scene, GameObject gameObject) {
            scene.gameObjects.Remove(gameObject);
        }


        public static void SetMainCamera(Camera camera) {
            currentScene.mainCamera = camera;
        }


        public static void LoadScene(Scene scene) {
            currentScene = scene;

            foreach (GameObject gameObjects in currentScene.gameObjects) {
                gameObjects.Start();
            }
        }


        public static void UnloadScene() {
            if (currentScene == null) {
                Debug.LogWarn("tried to unload scene without having a loaded scene");
                return;
            }

            foreach (GameObject gameObject in currentScene.gameObjects) {
                gameObject.Dispose();
            }

            currentScene = null!;
        }


        // These functions are to be used within the Application class
        public static void UpdateScene(double deltaTime) {
            if (currentScene == null) return;

            foreach (GameObject gameObject in currentScene.gameObjects) {
                gameObject.Update(deltaTime);
            }
        }


        public static void RenderScene(double deltaTime) {
            if (currentScene == null) return;

            foreach (GameObject gameObject in currentScene.gameObjects) {
                gameObject.Render(deltaTime);
            }
        }
    }
}
