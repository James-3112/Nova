namespace NovaEngine {
    public class Mesh : Component {
        public MeshBackend backend = null!;
        public float[] vertices = null!;
        public uint[] indices = null!;


        public Mesh(float[] vertices, uint[] indices) {
            this.vertices = vertices;
            this.indices = indices;
        }
        

        public override void Start() {
            backend = RendererLayer.CreateMeshBackend(vertices, indices);
        }
    }
}
