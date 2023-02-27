using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    float vertical;
    float horizontal;
    public float speed = 1.0f;
    float liveTime = 5.0f;
    float timer = 0.0f;

    void Start()
    {
        vertical = Camera.main.orthographicSize;
        horizontal = Camera.main.orthographicSize * 2f;
        timer = liveTime;
    }

    void Update()
    {
        Vector3 movement = new Vector3(0.0f, -speed, 0);
        transform.position += transform.rotation * movement * Time.deltaTime;

        {
            if (timer <= 0.0f)
            {
                Destroy(gameObject);
                timer = liveTime;
            }
        }
        timer -= Time.deltaTime;
    }
}
