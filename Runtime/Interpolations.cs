using UnityEngine;

namespace UrFairy
{
    public static class Interpolations
    {
        public static float Expo(float to, float current, float speed, float dt)
        {
            return Mathf.Lerp(to, current, Mathf.Exp(-speed * dt));
        }

        public static Vector2 Expo(Vector2 to, Vector2 current, float speed, float dt)
        {
            return Vector2.Lerp(to, current, Mathf.Exp(-speed * dt));
        }

        public static Vector3 Expo(Vector3 to, Vector3 current, float speed, float dt)
        {
            return Vector3.Lerp(to, current, Mathf.Exp(-speed * dt));
        }

        public static Vector4 Expo(Vector4 to, Vector4 current, float speed, float dt)
        {
            return Vector4.Lerp(to, current, Mathf.Exp(-speed * dt));
        }

        public static Quaternion Expo(Quaternion to, Quaternion current, float speed, float dt)
        {
            return Quaternion.Slerp(to, current, Mathf.Exp(-speed * dt));
        }

        public static float CriticallyDamped(float to, float current, ref float velocity, float speed, float dt)
        {
            var n1 = velocity - (current - to) * (speed * speed * dt);
            var n2 = 1 + speed * dt;
            velocity = n1 / (n2 * n2);
            return current + velocity * dt;
        }

        public static Vector2 CriticallyDamped(Vector2 to, Vector2 current, ref Vector2 velocity, float speed, float dt)
        {
            var n1 = velocity - (current - to) * (speed * speed * dt);
            var n2 = 1 + speed * dt;
            velocity = n1 / (n2 * n2);
            return current + velocity * dt;
        }

        public static Vector3 CriticallyDamped(Vector3 to, Vector3 current, ref Vector3 velocity, float speed, float dt)
        {
            var n1 = velocity - (current - to) * (speed * speed * dt);
            var n2 = 1 + speed * dt;
            velocity = n1 / (n2 * n2);
            return current + velocity * dt;
        }

        public static Vector4 CriticallyDamped(Vector4 to, Vector4 current, ref Vector4 velocity, float speed, float dt)
        {
            var n1 = velocity - (current - to) * (speed * speed * dt);
            var n2 = 1 + speed * dt;
            velocity = n1 / (n2 * n2);
            return current + velocity * dt;
        }

        public static Quaternion CriticallyDamped(Quaternion to, Quaternion current, ref Vector4 velocity, float speed, float dt)
        {
            var vTo = new Vector4(to.x, to.y, to.z, to.w);
            var vCurrent = new Vector4(current.x, current.y, current.z, current.w);
            if (Vector4.Dot(vCurrent, vTo) < 0)
            {
                vTo = -vTo;
            }

            var n1 = velocity - (vCurrent - vTo) * (speed * speed * dt);
            var n2 = 1 + speed * dt;
            velocity = n1 / (n2 * n2);
            var r = Vector4.Normalize(vCurrent + velocity * dt);
            return new Quaternion(r.x, r.y, r.z, r.w);
        }
    }
}