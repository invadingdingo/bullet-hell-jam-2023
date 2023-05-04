using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour {
    [SerializeField] private LayerMask playerFilter;
    public Transform Find() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 50f, playerFilter);

        if (hit.gameObject.tag == "Player")
            return hit.gameObject.transform;
        else
            return null;
    }

}
