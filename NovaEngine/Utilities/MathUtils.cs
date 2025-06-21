using System.Numerics;

namespace NovaEngine {
    public static class MathUtils {
        public static float DegreesToRadians(float degrees) => MathF.PI / 180f * degrees;


        public static float RadiansToDegrees(float radians) => radians * (180f / MathF.PI);


        public static Quaternion EulerAnglesToQuaternion(float x, float y, float z) {
            return Quaternion.CreateFromYawPitchRoll(
                DegreesToRadians(y), // yaw (Y axis)
                DegreesToRadians(x), // pitch (X axis)
                DegreesToRadians(z)  // roll (Z axis)
            );
        }


        public static Quaternion EulerAnglesToQuaternion(Vector3 eulerAngles) {
            return EulerAnglesToQuaternion(eulerAngles.X, eulerAngles.Y, eulerAngles.Z);
        }


        public static Vector3 QuaternionToEulerAngles(Quaternion q) {
            // Convert quaternion to euler angles in radians
            float sinr_cosp = 2 * (q.W * q.X + q.Y * q.Z);
            float cosr_cosp = 1 - 2 * (q.X * q.X + q.Y * q.Y);
            float roll = MathF.Atan2(sinr_cosp, cosr_cosp);

            float sinp = 2 * (q.W * q.Y - q.Z * q.X);
            float pitch = MathF.Abs(sinp) >= 1
                ? MathF.CopySign(MathF.PI / 2, sinp)
                : MathF.Asin(sinp);

            float siny_cosp = 2 * (q.W * q.Z + q.X * q.Y);
            float cosy_cosp = 1 - 2 * (q.Y * q.Y + q.Z * q.Z);
            float yaw = MathF.Atan2(siny_cosp, cosy_cosp);

            // Convert to degrees
            return new Vector3(
                RadiansToDegrees(pitch),
                RadiansToDegrees(yaw),
                RadiansToDegrees(roll)
            );
        }
    }
}
