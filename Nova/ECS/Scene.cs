namespace Nova;


public class Scene {
    Register entityIdRegister = new Register(0);
    Database componentsDatabase = new Database();

    public Entity CreateEntity() {
        return new Entity(entityIdRegister.GetId());
    }

    public void DestroyEntity(Entity entity) {
        entityIdRegister.ReturnId(entity.id);
    }

    public void OnStart() {}
    public void OnUpdate() {}
    public void OnShutdown() {}
}
