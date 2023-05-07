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

    public static Vector3 Infinity(float scale, float angle) {
        float t = Mathf.Deg2Rad * angle;
        float r = 2f / (3f - Mathf.Cos(2f * t));
        float x = scale * r * Mathf.Cos(t);
        float y = scale * r * Mathf.Sin(2f * t) / 2f;
        return new Vector3(x, y, 0f);
    }

    public static Vector3 Flower(float scale, float angle) {
        float t = Mathf.Deg2Rad * angle;
        float r = 1f + Mathf.Cos(6f * t);
        return Circle(scale * r, angle);
    }

    public static Vector3 Star(int points, float scale, float angle) {
        float t = Mathf.Deg2Rad * angle;
        float r = 1f + 0.15f * Mathf.Sin(points * t + Mathf.PI / 2f);
        return Circle(scale * r, angle);
    }

    public static Vector3 Square(float scale, float angle) {
        float t = ((angle + 45f) % 90 - 45f) / 180f * Mathf.PI;
        float r = 1f / Mathf.Cos(t);
        return Circle(scale * r, angle);
    }

    public static Vector3 Line(float scale, float angle) {
        float t = Mathf.Deg2Rad * angle;
        float x = scale * Mathf.Cos(t);
        return new Vector3(x, 0f, 0f);
    }
}
