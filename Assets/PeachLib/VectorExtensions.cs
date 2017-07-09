using UnityEngine;

public static class VectorExtensions {

    public static Quaternion GetRotationAngleTowardsTarget(this Vector3 self, Vector3 target)
    {
        Vector3 vectorToTarget = self- target;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        return q;
    }

    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        return Quaternion.Euler(0, 0, degrees) * v;
    }
}
