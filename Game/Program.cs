using NovaEngine;


class Program {
    static void Main(string[] args) {
        Scene scene = new Scene();

        GameObject gameObject = new GameObject("Test GameObject");
        gameObject.AddComponent(new Player());

        scene.AddGameObject(gameObject);

        Application.Start(scene);
    }
}
