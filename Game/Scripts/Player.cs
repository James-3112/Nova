using NovaEngine;


public class Player : Component {
    public override void Start() => Console.WriteLine("Player started.");
    public override void Update(double deltaTime) =>
        Console.WriteLine($"Updating player with dt={deltaTime}");
}
