using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public SingleBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public GameObject[] spawnPoint;
    public float bulletSpeed;
    public AudioClip ShootAudio;

    private Transform currentSpawn;
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

            SingleBulletPattern pattern = Instantiate(BulletPattern, currentSpawn.position, Quaternion.identity);

            pattern.Spawn(
                prefab: BulletPrefab,
                direction: (Quaternion.Euler(0, 0, transform.eulerAngles.z + 90f) * Vector3.right).normalized,
                speed: bulletSpeed
            );

            GameManager.instance.PlaySfx(ShootAudio);
        }
    }
}
