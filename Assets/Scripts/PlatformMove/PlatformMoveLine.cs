using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveLine : MonoBehaviour {
    public float Scale = 10f;
    public float Speed = 30f;

    private Vector3 startPosition;
    private float angle;

    void Start() {
        startPosition = transform.position;
        angle = 0f;
    }

    void Update() {
        Vector3 offset = Vector3.left * Scale;
        transform.position = startPosition + offset + Polar.Line(Scale, angle);
        angle += Speed * Time.deltaTime;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        int points = 10;
        float interval = 360f / points;
        for (int i = 0; i < points; i++) {
            Vector3 offset = Vector3.left * Scale;
            Vector3 p0 = offset + transform.position + Polar.Line(Scale, interval * i);
            Vector3 p1 = offset + transform.position + Polar.Line(Scale, interval * (i + 1));
            Gizmos.DrawLine(p0, p1);
        }
    }
}
