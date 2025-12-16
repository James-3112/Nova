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
        if (pool.TryPop(out T? poolObject)) return poolObject;
        return factory();
    }

    public void ReturnObject(T poolObject) {
        pool.Push(poolObject);
    }
}
