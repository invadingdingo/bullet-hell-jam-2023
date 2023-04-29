using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

public float speed;
public Vector2 direction;

    // Update is called once per frame
    void Update() {
        direction.x = Input.GetAxisRaw("horizontal");
        direction.y = Input.GetAxisRaw("vertical");

        
    }
}
