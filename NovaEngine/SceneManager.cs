namespace NovaEngine {
    public static class SceneManager {
        public static Scene currentScene = null!;


        public static void AddGameObject(GameObject gameObject) {
            currentScene.AddGameObject(gameObject);
        }


        public static void RemoveGameObject(GameObject gameObject) {
            currentScene.RemoveGameObject(gameObject);
        }


        public static void SetMainCamera(Camera camera) {
            currentScene.mainCamera = camera;
        }


        // public static void SaveScene(Scene scene, string filePath) {
        //     var serializableScene = new {
        //         gameObjects = scene.gameObjects.Select(SceneConverter.ToSerializable).ToList()
        //     };

        //     Json.Save(serializableScene, filePath);
        // }


        // public static Scene LoadScene(string filePath) {
        //     var loadedData = Json.Load<Dictionary<string, List<SerializableGameObject>>>(filePath);

        //     Scene scene = new Scene();
        //     foreach (var objData in loadedData["gameObjects"]) {
        //         scene.AddGameObject(SceneConverter.FromSerializable(objData));
        //     }

        //     return scene;
        // }


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
        public static void StartScene(Scene scene) {
            currentScene = scene;
            currentScene.Start();
        }


        public static void UpdateScene(double deltaTime) {
            if (currentScene == null) return;
            currentScene.Update(deltaTime);
        }


        public static void RenderScene(double deltaTime) {
            if (currentScene == null) return;
            currentScene.Render(deltaTime);
        }
    }
}
