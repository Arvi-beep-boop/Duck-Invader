using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public bool suppress;
    public bool fastShooting;
    public GameObject ammo;
    public Animator animator;

    float shootCooldownLeft;
    float shootCooldownRight;
    float timerShootLeft;
    float timerShootRight;
    float angryShootCooldown = 0.2f;
    Vector3 offset = new Vector3(0.0f, -2.5f, 0.0f);
    private AudioSource shootPop;

    void Start()
    {
        suppress = true;
        shootCooldownLeft = Random.Range(2.0f, 4.0f);
        shootCooldownRight = Random.Range(2.0f, 4.0f);
        timerShootLeft = shootCooldownLeft;
        timerShootRight = shootCooldownRight;
        fastShooting = false;
        shootPop = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (suppress == false)
        {
            
            if (timerShootLeft <= 0.0f)
            {
                
                GameObject.Instantiate(ammo, transform.position + offset, transform.rotation);
                shootPop.Play();
                animator.SetBool("IsBossShooting", true);



                if (fastShooting)
                    timerShootLeft = angryShootCooldown;
                else
                {
                    timerShootLeft = Random.Range(2.0f, 4.0f);
                    animator.SetBool("IsBossShooting", false);
                }

            }
           
            timerShootLeft -= Time.deltaTime;
            timerShootRight -= Time.deltaTime;
            

            
            
        }
    }
}
