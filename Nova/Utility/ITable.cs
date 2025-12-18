namespace Nova;


public interface ITable {
    public void ForEach(Action<int, object> action);
}
