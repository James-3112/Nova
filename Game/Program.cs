using System.Numerics;
using Nova;

class Program {
    static void Main(string[] args) {
        // Application application = new Application();
        // application.Run();

        SceneManager sceneManager = new SceneManager();
        Scene scene = sceneManager.CreateScene();
        Entity entity = scene.CreateEntity();
        scene.componentsDatabase.GetTable<Transform>().Set(entity.id, new Transform { positionX = 5});
        Console.WriteLine(scene.componentsDatabase.GetTable<Transform>().Get(entity.id).positionX);

        sceneManager.SaveScene(scene);
    }
}
