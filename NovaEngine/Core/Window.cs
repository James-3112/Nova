using Silk.NET.Maths;
using Silk.NET.Windowing;


namespace NovaEngine {
    public class Window {
        public IWindow silkWindow = null!;


        public Window(int width = 800, int height = 600, string title = "Nova") {
            WindowOptions options = WindowOptions.Default with {
                Size = new Vector2D<int>(width, height),
                Title = title
            };

            silkWindow = Silk.NET.Windowing.Window.Create(options);
        }


        public Window(WindowOptions windowOptions) {
            silkWindow = Silk.NET.Windowing.Window.Create(windowOptions);
        }


        public void Start() {
            silkWindow.Run();
            silkWindow.Dispose();
        }


        public void Close() {
            silkWindow.Close();
        }
    }
}
