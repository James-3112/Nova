namespace NovaEngine {
    public static class SceneManager {
        public static SceneLayer sceneLayer = null!;


        public static void Initialize(SceneLayer sceneLayer) {
            SceneManager.sceneLayer = sceneLayer;
        }


        public static void LoadScene(Scene scene) {
            if (sceneLayer == null) {
                Debug.LogError("SceneLayer has not been initialized");
                return;
            }

            UnloadCurrentScene();
            sceneLayer.scene = scene;
            scene.Start();
        }


        public static void UnloadCurrentScene() {
            if (sceneLayer == null) {
                Debug.LogError("SceneLayer has not been initialized");
                return;
            }

            if (sceneLayer.scene == null) {
                Debug.LogWarn("Tried to unload a scene, but no scene is currently loaded");
                return;
            }

            sceneLayer.scene?.Dispose();
            sceneLayer.scene = null!;
        }
    }
}
