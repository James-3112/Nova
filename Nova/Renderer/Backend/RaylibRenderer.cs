using Raylib_cs;

namespace Nova;


public class RaylibRenderer : Renderer {
    // Takes a scene and the asset pool - Note, should send draw commands like draw box here instad of the hole scene so that it can be used for other thing like UI
    public override void Render() {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        Raylib.EndDrawing();
    }
}
