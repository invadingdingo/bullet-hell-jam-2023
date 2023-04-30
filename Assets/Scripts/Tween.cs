using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Tween {
    public static void Animate(MonoBehaviour obj, float start, float end, float duration, Func<float, float> interpolateFn, Action<float> fn) {
        obj.StartCoroutine(Animator(start, end, duration, interpolateFn, fn));
    }

    public static float Linear(float t) {
        return t;
    }

    public static float EaseIn(float t) {
        return Square(t);
    }

    public static float EaseOut(float t) {
        return Flip(Square(Flip(t)));
    }

    public static float EaseInOut(float t) {
        return Mathf.Lerp(EaseIn(t), EaseOut(t), t);
    }

    public static float Spike(float t) {
        if (t <= 0.5f) {
            return EaseIn(t / 0.5f);
        }
        return EaseIn(Flip(t) / 0.5f);
    }

    static IEnumerator Animator(float start, float end, float duration, Func<float, float> interpolateFn, Action<float> fn) {
        float time = 0f;
        while (time < duration) {
            fn(Mathf.Lerp(start, end, interpolateFn(time / duration)));
            time += Time.deltaTime;
            yield return null;
        }
        fn(Mathf.Lerp(start, end, interpolateFn(1f)));
    }

    static float Flip(float t) {
        return 1f - t;
    }

    static float Square(float t) {
        return t * t;
    }
}
