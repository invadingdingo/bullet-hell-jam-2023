using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public StraightBullet Bullet;
    public GameObject[] spawnPoint;
    private Transform currentSpawn;

    public float bulletSpeed;
    private bool shootRight;
    
    void Start() {
        BeatManager.instance.AddTriplet(Fire);
    }

    void Fire() {
        if (Input.GetButton("Fire")) {

            if (shootRight) {
                currentSpawn = spawnPoint[0].transform;
            } else {
                currentSpawn = spawnPoint[1].transform;
            }

            shootRight = !shootRight;

            StraightBullet pattern = Instantiate(Bullet, currentSpawn.position, Quaternion.identity);

            pattern.Spawn(
                direction: (Quaternion.Euler(0, 0, transform.eulerAngles.z + 90f) * Vector3.right).normalized,
                speed: bulletSpeed
            );

            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
        }
    }
}
