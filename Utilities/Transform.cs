using System.Numerics;


namespace Nova.Utilities {
    public class Transform {
        public Vector3 position = new Vector3(0,0,0);
        public float scale = 1f;
        
        private Quaternion _rotation = Quaternion.Identity;
        private Vector3 _rotationEulerAngles = Vector3.Zero;

        public Quaternion rotation {
            get => _rotation;
            set {
                _rotation = value;
                _rotationEulerAngles = MathUtils.QuaternionToEulerAngles(_rotation);
            }
        }

        public Vector3 rotationEulerAngles {
            get => _rotationEulerAngles;
            set {
                _rotationEulerAngles = value;
                _rotation = MathUtils.EulerAnglesToQuaternion(value.X, value.Y, value.Z);
            }
        }

        public float rotationEulerX {
            get => _rotationEulerAngles.X;
            set => rotationEulerAngles = new Vector3(value, _rotationEulerAngles.Y, _rotationEulerAngles.Z);
        }

        public float rotationEulerY {
            get => _rotationEulerAngles.Y;
            set => rotationEulerAngles = new Vector3(_rotationEulerAngles.X, value, _rotationEulerAngles.Z);
        }

        public float rotationEulerZ {
            get => _rotationEulerAngles.Z;
            set => rotationEulerAngles = new Vector3(_rotationEulerAngles.X, _rotationEulerAngles.Y, value);
        }

        public Matrix4x4 matrix => Matrix4x4.CreateFromQuaternion(_rotation) * Matrix4x4.CreateScale(scale) * Matrix4x4.CreateTranslation(position);
    }
}
