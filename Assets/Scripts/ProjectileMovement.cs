using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 2.0f;
    float top;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
            
        }

    }
    void Start()
    {
        top = Camera.main.orthographicSize;
        

    }

    void Update()
    {
        
        Vector3 movement = new Vector3(0.0f, speed, 0);
        transform.position += movement * Time.deltaTime;

        if (transform.position.y > top)
        {
            Destroy(gameObject);
        }
    }
}
