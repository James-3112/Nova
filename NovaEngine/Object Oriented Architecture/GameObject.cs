namespace NovaEngine {
    public class GameObject {
        public string name;
        public GameObject parent = null!;
        public bool enabled = true;

        private List<GameObject> gameObjects = new();
        private List<Component> components = new();


        public GameObject(string name = "GameObject") {
            this.name = name;
        }


        #region Game Objects
        // Add a game object as a child of this game object
        public GameObject AddGameObject(GameObject gameObject = null!) {
            if (gameObject == null) gameObject = new GameObject();

            gameObject.parent = this;
            gameObjects.Add(gameObject);
            gameObject.Start();

            return gameObject;
        }


        // Get the game object using it's name only within it's immediate children
        public GameObject GetGameObject(string name) {
            foreach (GameObject gameObject in gameObjects) {
                if (gameObject.name == name) return gameObject;
            }

            return null!;
        }

        
        // Gets all the game objects immediate children
        public List<GameObject> GetGameObjects() {
            return gameObjects;
        }


        // Gets all the game objects children, including children with in the children of objects
        public List<GameObject> GetAllGameObjects(List<GameObject> list = null!) {
            if (list == null) list = new List<GameObject>();

            list.Add(this);
            foreach (GameObject child in gameObjects) {
                child.GetAllGameObjects(list);
            }

            return list;
        }
        #endregion


        #region Components
        // Adds a component that is already created to the game object
        public Component AddComponent(Component component) {
            component.gameObject = this;
            components.Add(component);
            component.Start();

            return component;
        }


        // Creates and adds a component to the game object
        public ComponentType AddComponent<ComponentType>(ComponentType component) where ComponentType : Component {
            component.gameObject = this;
            components.Add(component);
            component.Start();

            return component;
        }


        // Gets a component of a specific type
        public ComponentType GetComponent<ComponentType>() where ComponentType : Component {
            return components.OfType<ComponentType>().FirstOrDefault()!;
        }

        
        // Gets all the immediate components
        public List<Component> GetComponents() {
            return components;
        }


        // Gets a component of a specific type within it's children, including children with in the children of objects
        public ComponentType GetComponentInChildren<ComponentType>() where ComponentType : Component {
            ComponentType component = GetComponent<ComponentType>();
            if (component != null) return component;

            foreach (GameObject child in gameObjects) {
                ComponentType childComponent = child.GetComponentInChildren<ComponentType>();
                if (childComponent != null) return childComponent;
            }

            return null!;
        }
        #endregion


        #region Events
        // Starts all game objects and components
        public void Start() {
            if (enabled == false) return;
            
            foreach (GameObject gameObject in gameObjects) {
                if (gameObject.enabled) gameObject.Start();
            }

            foreach (Component component in components) {
                if (component.enabled) component.Start();
            }
        }

        
        // Updates all game objects and components
        public void Update(double deltaTime) {
            if (enabled == false) return;

            foreach (GameObject gameObject in gameObjects) {
                if (gameObject.enabled) gameObject.Update(deltaTime);
            }

            foreach (Component component in components) {
                if (component.enabled) component.Update(deltaTime);
            }
        }

        
        // Disposes of all game objects and components
        public void Dispose() {
            foreach (GameObject gameObject in gameObjects) {
                gameObject.Dispose();
            }

            foreach (Component component in components) {
                if (component is IDisposable disposable) disposable.Dispose();
            }
        }
        #endregion
    }
}
