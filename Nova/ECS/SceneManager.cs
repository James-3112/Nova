using System.Text.Json;

namespace Nova;


public class SceneManager() {
    private List<Scene> scenes = new List<Scene>();
    private Scene? currentScene;

    public Scene CreateScene() {
        Scene scene = new Scene();
        scenes.Add(scene);
        return scene;
    }

    public void DeleteScene(Scene scene) {
        scenes.Remove(scene);
    }

    public void SetOpenScene(Scene scene) {
        currentScene = scene;
    }

    public Scene? GetOpenScene() {
        return currentScene;
    }

    public void SaveScene(Scene scene) {
        JsonSerializerOptions options = new JsonSerializerOptions {IncludeFields = true, WriteIndented = true};
        string json = JsonSerializer.Serialize(scene.CreateSaveData(), options);
        Console.WriteLine(json);
    }

    public void LoadScene() {

    }
}
