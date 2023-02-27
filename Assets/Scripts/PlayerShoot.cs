using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject ammo;
    public float shootCooldown = .5f; 
    float timer = 0.0f;
    public Animator animator;

    private AudioSource popPop;
    void Start()
    {
        timer = shootCooldown;
        popPop = GetComponent<AudioSource>();
    }

    void Update()
    {
        float shoot = Input.GetAxisRaw("Jump");
        if (shoot > 0 && timer <= 0.0f)
        {
            animator.SetBool("IsShooting", true);
            popPop.Play();
            GameObject.Instantiate(ammo, transform.position, transform.rotation);
            timer = shootCooldown;
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }
        timer -= Time.deltaTime;
    }
}
