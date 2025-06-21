using NovaEngine;


class Program {
    static void Main(string[] args) {
        Scene.Load(new Scene());

        GameObject player = new GameObject();
        player.AddComponent(new Player()).Start();
        player.Update(1.0f);

        Scene.Unload();
    }
}
