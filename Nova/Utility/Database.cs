namespace Nova;


public class Database {
    private Dictionary<Type, object> tables = new Dictionary<Type, object>();

    public Table<T> Table<T>() {
        Type type = typeof(T);

        if (!tables.TryGetValue(type, out var table)) {
            table = new Table<T>();
            tables[type] = table;
        }

        return (Table<T>)table;
    }
}
