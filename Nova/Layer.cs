namespace Nova;


public abstract class Layer {
    public virtual void OnAttach() {}
    public virtual void OnDetach() {}
    public virtual void OnUpdate() {}
}
