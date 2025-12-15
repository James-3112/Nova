namespace Nova;


public abstract class Renderer {
    public abstract void Render(); // Takes a scene and the asset pool - Note, should send draw commands like draw box here instad of the hole scene so that it can be used for other thing like UI
}
