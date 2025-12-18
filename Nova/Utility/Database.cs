namespace Nova;


public class Database {
    public Dictionary<Type, ITable> tables = new Dictionary<Type, ITable>();

    public Table<T> GetTable<T>() {
        Type type = typeof(T);

        if (!tables.TryGetValue(type, out ITable? table)) {
            table = new Table<T>();
            tables[type] = table;
        }

        return (Table<T>)table;
    }
}
