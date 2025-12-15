namespace Nova;


public class RenderLayer : Layer {
    public enum Backend {Raylib}
    private Renderer renderer;

    public RenderLayer(Backend backend) {
        switch (backend) {
            case Backend.Raylib:
                renderer = new RaylibRenderer();
                break;
            default:
                throw new ArgumentException("Unsupported platform");
        }
    }

    public override void OnAttach() {}
    public override void OnDetach() {}

    public override void OnUpdate() {
        renderer.Render();
    }
}
