namespace Nova;


public class Pool<T> {
    private Stack<T> pool;
    private Func<T> factory;

    public Pool(int startSize, Func<T> factory) {
        pool = new Stack<T>(startSize);
        this.factory = factory;

        for (int i = 0; i < startSize; i++) {
            pool.Push(factory());
        }
    }

    public T GetObject() {
        return pool.Count > 0 ? pool.Pop() : factory();
    }

    public void ReturnObject(T poolObject) {
        pool.Push(poolObject);
    }
}
