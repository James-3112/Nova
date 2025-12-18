namespace Nova;


public class Scene {
    public Register entityIdRegister = new Register(0);
    public Database componentsDatabase = new Database();

    public Entity CreateEntity() {
        return new Entity(entityIdRegister.GetId());
    }

    public void DestroyEntity(Entity entity) {
        entityIdRegister.ReturnId(entity.id);
    }

    public SceneSaveData CreateSaveData() {
        SceneSaveData sceneSaveData = new SceneSaveData();
        sceneSaveData.nextEntityId = entityIdRegister.nextId;

        foreach (KeyValuePair<Type, ITable> table in componentsDatabase.tables) {
            Dictionary<int, object> components = new Dictionary<int, object>();

            table.Value.ForEach((entityId, component) => {
                components[entityId] = component;
            });

            sceneSaveData.components[table.Key.Name] = components;
        }

        return sceneSaveData;
    }
}
