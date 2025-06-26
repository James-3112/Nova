namespace NovaEngine {
    public class Mesh : Component {
        public MeshBackend backend;

        public Mesh(MeshBackend backend) {
            this.backend = backend;
        }
    }
}
