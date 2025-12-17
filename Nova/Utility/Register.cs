namespace Nova;


public class Register {
    private Stack<int> registry;
    private int nextId = 0;

    public Register(int startSize) {
        registry = new Stack<int>(startSize);

        for (; nextId < startSize; nextId++) {
            registry.Push(nextId);
        }
    }

    public int GetId() {
        return registry.Count > 0 ? registry.Pop() : nextId++;
    }

    public void ReturnId(int id) {
        registry.Push(id);
    }
}
