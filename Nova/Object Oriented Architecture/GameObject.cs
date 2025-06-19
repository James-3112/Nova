namespace Nova.ObjectOrientedArchitecture {
    public class GameObject {
        public string name;
        public bool active = true;

        private List<Component> components = new();


        public GameObject(string name = "GameObject") {
            this.name = name;
        }


        public Type AddComponent<Type>(Type component) where Type : Component {
            component.gameObject = this;
            components.Add(component);
            component.OnAdd();
            return component;
        }


        public Type GetComponent<Type>() where Type : Component {
            return components.OfType<Type>().FirstOrDefault()!;
        }


        public void Update() {
            if (!active) return;

            foreach (Component component in components) {
                if (component.enabled) component.Update();
            }
        }

        public void Dispose() {
            foreach (Component component in components) {
                if (component is IDisposable disposable)
                    disposable.Dispose();
            }
        }
    }
}
