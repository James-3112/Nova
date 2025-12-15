using Raylib_cs;

namespace Nova;


public class Application {
    Window window;

    public Application() {
        window = WindowFactory.CreateWindow(WindowFactory.Backend.Raylib);
    }

    public void Run() {
        window.Open();

        while (!window.WindowShouldClose()) {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.EndDrawing();
        }

        Stop();
    }

    public void Stop() {
        window.Close();
    }
}
