using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {
    public void OnAnimationEnd() {
        Destroy(gameObject);
    }
}
