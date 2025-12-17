namespace Nova;


public class Table<T> {
    private Dictionary<int, T> rows = new Dictionary<int, T>();

    public bool Has(int id) {
        return rows.ContainsKey(id);
    }

    public bool Has(T value) {
        return rows.ContainsValue(value);
    }

    // Returns the raw value, meaning to update it in the table you would have to set it again
    public T Get(int id) {
        return rows[id];
    }

    // Returns the ref (pointer) of the value, meaning you can treat it like a class
    public bool GetRef(int id, out T? value) {
        return rows.TryGetValue(id, out value);
    }
    
    public void Set(int id, T value) {
        rows[id] = value;
    }


    public void Remove(int id) {
        rows.Remove(id);
    }
}
