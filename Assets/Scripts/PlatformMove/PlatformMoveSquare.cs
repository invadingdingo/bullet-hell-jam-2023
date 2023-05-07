using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveSquare : MonoBehaviour {
    public float Scale = 10f;
    public float Speed = 30f;
    public float Offset = 0f;

    private Vector3 startPosition;
    private float angle;

    void Start() {
        startPosition = transform.position;
        angle = 0f;
    }

    void Update() {
        Vector3 offset = Vector3.left * Scale;
        transform.position = startPosition + offset + Polar.Square(Scale, angle + Offset);
        angle += Speed * Time.deltaTime;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        int points = 100;
        float interval = 360f / points;
        for (int i = 0; i < points; i++) {
            Vector3 offset = Vector3.left * Scale;
            Vector3 p0 = offset + transform.position + Polar.Square(Scale, interval * i);
            Vector3 p1 = offset + transform.position + Polar.Square(Scale, interval * (i + 1));
            Gizmos.DrawLine(p0, p1);
        }
    }
}
