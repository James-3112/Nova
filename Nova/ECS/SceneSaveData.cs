namespace Nova;


public class SceneSaveData {
    public int nextEntityId;
    public Dictionary<string, Dictionary<int, object>> components = new Dictionary<string, Dictionary<int, object>>();
}
