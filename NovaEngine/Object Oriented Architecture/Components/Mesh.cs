namespace NovaEngine {
    public class Mesh : Component {
        public MeshBackend backend;

        public Mesh(float[] vertices, uint[] indices) {
            backend = RendererLayer.CreateMeshBackend(vertices, indices);
        }

        public Mesh(MeshBackend backend) {
            this.backend = backend;
        }
    }
}
