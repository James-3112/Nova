using NovaEngine;


class Program {
    static void Main(string[] args) {
        SceneManager.LoadScene(new Scene());

        GameObject player = new GameObject();
        player.AddComponent(new Player()).Start();
        player.Update(1.0f);

        SceneManager.UnloadScene();
    }
}
