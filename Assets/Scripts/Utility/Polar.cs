using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Polar {
    public static Vector3 Circle(float radius, float angle) {
        float t = Mathf.Deg2Rad * angle;
        float x = radius * Mathf.Cos(t);
        float y = radius * Mathf.Sin(t);
        return new Vector3(x, y, 0f);
    }

    public static Vector3 Flower(float scale, float angle) {
        float t = Mathf.Deg2Rad * angle;
        float r = 1f + Mathf.Cos(6f * t);
        return Circle(scale * r, angle);
    }
}
