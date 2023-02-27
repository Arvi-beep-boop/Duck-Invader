using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossMovement : MonoBehaviour
{
    Vector3 newTarget;
    public float speed;
    Vector3 targetDirection;
    bool laserStarted;
    float angleSpeed = 35.0f;
    float angleRotation = 720.0f;
    float angleRotated;
  
   
    void Start()
    {
        transform.position = new Vector3(0.0f, 10.0f, 0.0f);
        newTarget = new Vector3(0.0f, 1.0f, 0.0f);
        angleRotated = angleRotation;
    }

    void Update()
    {
        targetDirection = newTarget - transform.position;
        if (IsTargetReached() == false)
        {
            transform.position += targetDirection.normalized * speed * Time.deltaTime;
        }
        if (laserStarted == true)
        {
            Quaternion quaternion = Quaternion.Euler(0.0f, 0.0f, angleSpeed * Time.deltaTime);
            transform.rotation *= quaternion;
            angleRotated -= angleSpeed * Time.deltaTime;

        }
        if (IsLaserRollFinished())
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            laserStarted = false;
        }
    }
    public void SetNewMoveTarget(Vector3 target)
    {
        newTarget = target;
    }
    public bool IsTargetReached()
    {
        Vector3 distance = transform.position - newTarget;
        if (distance.magnitude <= 0.1f)
            return true;
        else
            return false;
    }
    public void StartLaserRoll()
    {
        laserStarted = true;
    }
    public bool IsLaserRollFinished()
    {
        if (angleRotated <= 0.0f)
            return true;
        else
            return false;
    }
    public void SetNewRotation()
    {
        angleRotated = angleRotation;
    }

}
