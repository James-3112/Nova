using Raylib_cs;

namespace Nova;


public class RaylibWindow : Window {
    public override void Open() {
        Raylib.InitWindow(800, 480, "Hello World");
    }

    public override void Close() {
        Raylib.CloseWindow();
    }

    public override bool WindowShouldClose() {
        return Raylib.WindowShouldClose();
    }
}
