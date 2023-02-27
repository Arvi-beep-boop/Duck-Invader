using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum BossState
{
    Unknown = 0,
    EnterWorld,
    Regular,
    Angry,
    LaserRoll,

}
public class BossLogic : MonoBehaviour
{
    BossMovement movement;
    BossShooting guns;
    Health health;
    BossLaser laser;
    Animator animator;

    BossState state = BossState.Unknown;
    BossState lastFrameState = BossState.Unknown;

    float flipFlopSideScalar = 1.0f;
    float laserCooldown = 0.0f;
    bool laserRollStarted = false;

    void Start()
    {
        movement = gameObject.GetComponent<BossMovement>();
        guns = gameObject.GetComponent<BossShooting>();
        health = gameObject.GetComponent<Health>();
        laser = gameObject.GetComponent<BossLaser>();
        animator = gameObject.GetComponent<Animator>();

        laser.suppress = true;
        guns.suppress = false;

        state = BossState.EnterWorld;
    }

    void Update()
    {
        if (state == BossState.EnterWorld)
        { 
            // on enter
            if (state != lastFrameState)
            {
                lastFrameState = state;

                movement.SetNewMoveTarget(new Vector3(0.0f, 3.0f, 0.0f));

                guns.suppress = true;
            }
            // on update
            {

            }
            // transitions
            if (movement.IsTargetReached())
            {
                state = BossState.Regular;
            }
            // on exit
            if (state != lastFrameState)
            {

            }
        }
        else if (state == BossState.Regular)
        {
            // on enter
            if (state != lastFrameState)
            {
                lastFrameState = state;

                guns.suppress = false;
            }

            // on update
            if (movement.IsTargetReached())
            {
                flipFlopSideScalar = -flipFlopSideScalar;
                movement.SetNewMoveTarget(new Vector3(4.0f * flipFlopSideScalar, 3.0f, 0.0f));
            }

            // transitions
             if (health.healthPoints <= 50.0f)
            {
                state = BossState.Angry;
            }
            // on exit
            if (state != lastFrameState)
            {

            }
        }
        else if (state == BossState.Angry)
        {
            //on enter
            if (state != lastFrameState)
            {
                lastFrameState = state;
                guns.fastShooting = true;
                laserCooldown = 5.0f;

            }
            //on update
            if (movement.IsTargetReached())
            { 
                flipFlopSideScalar = -flipFlopSideScalar;
                movement.SetNewMoveTarget(new Vector3(4.0f * flipFlopSideScalar, 2.0f, 0.0f));
            }

            laserCooldown -= Time.deltaTime;

            //transitions
            if (laserCooldown <= 0.0f)
            {
                state = BossState.LaserRoll;
            }
            //on exit
            if (state != lastFrameState)
            {

            }
        }
        else if (state == BossState.LaserRoll)
        {
            //on enter
            if (state != lastFrameState)
            {
                lastFrameState = state;
                guns.suppress = true;
                laser.suppress = true;
                laserCooldown = 2.0f;
                movement.SetNewRotation();

                movement.SetNewMoveTarget(new Vector3(0.0f, 0.0f, 0.0f));
                animator.SetBool("IsBossShooting", false);
            }
            //on update
            if (movement.IsTargetReached())
            {
                if(!laserRollStarted)
                {
                    laser.suppress = false;
                    movement.StartLaserRoll();
                    laserRollStarted = true;
                    animator.SetBool("IsBossShooting", true);

                }
            }

            //transitions
            if(laserRollStarted && movement.IsLaserRollFinished())
            {
                state = BossState.Angry;
                movement.SetNewMoveTarget(new Vector3(0.0f, 0.0f, 0.0f));
            }

            //on exit
            if (state != lastFrameState)
            {
                guns.suppress = false;
                laser.suppress = true;
                laserRollStarted = false;
                flipFlopSideScalar = -flipFlopSideScalar;
            }
        }
    }
}
