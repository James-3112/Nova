namespace Nova.ObjectOrientedArchitecture {
    public abstract class Component {
        public GameObject gameObject = null!;
        public bool enabled = true;

        public virtual void OnAdd() { }
        public virtual void Update() { }
    }
}
