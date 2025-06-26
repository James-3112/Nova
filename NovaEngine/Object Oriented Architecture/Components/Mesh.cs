namespace NovaEngine {
    public class Mesh : Component {
        public MeshBuffer buffer;

        public Mesh(MeshBuffer buffer) {
            this.buffer = buffer;
        }
    }
}
