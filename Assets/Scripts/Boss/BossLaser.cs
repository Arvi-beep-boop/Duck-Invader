using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public bool suppress;
    public GameObject ammo;
    float laserShootCooldown = 0.1f;
    float timer;
    Vector3 upperGun = new Vector3(0.0f, 3.0f, 0.0f);
    private AudioSource Popping;

    void Start()
    {
        timer = laserShootCooldown;
        Popping = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (suppress == false)
        {
            if (timer <= 0.0f)
            {
                GameObject.Instantiate(ammo, transform.position, transform.rotation);
                Popping.Play();
                GameObject.Instantiate(ammo, transform.position + transform.rotation*upperGun, transform.rotation * Quaternion.Euler(0.0f, 0.0f, 180.0f));

                timer = laserShootCooldown;
            }
            timer -= Time.deltaTime;
        }
    }
}
