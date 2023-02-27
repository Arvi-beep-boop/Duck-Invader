using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody rb;
    public float screen_size_horizontal = 10.0f;
    public float screen_size_vertical = 10.0f;
    GameObject enemy;
    float left;
    float right;
    float top;
    float bottom;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile")
            Destroy(gameObject);

    }

    void Start()
    {
        enemy = GameObject.Find("Enemy");
        float HalfSizeVertical = Camera.main.orthographicSize;
        float HalfSizeHorizontal = Camera.main.orthographicSize * Screen.width/Screen.height; // aspect ratio
        left = - HalfSizeHorizontal;
        right = HalfSizeHorizontal;
        top = HalfSizeVertical;
        bottom = -HalfSizeVertical; 
        transform.position = new Vector3(0.0f, - screen_size_vertical + 1.0f); // starting position, bottom of the screen
    }

    void Update()
    {
        float movement_x =  Input.GetAxisRaw("Horizontal");
        float movement_y = Input.GetAxisRaw("Vertical");
        Vector3 position = transform.position;
         
        transform.position += new Vector3(movement_x, movement_y, 0).normalized * speed * Time.deltaTime;
        if (transform.position.x > right || transform.position.x < left)
        {
            position.x = Mathf.Clamp(transform.position.x, left, right);
            transform.position = position;
        }
        if (transform.position.y > top || transform.position.y < bottom)
        {
            position.y = Mathf.Clamp(transform.position.y, bottom, top);
            transform.position = position;

        }

        //Box drawing

        Debug.DrawLine(new Vector3(screen_size_horizontal, -screen_size_vertical), new Vector3(screen_size_horizontal, screen_size_vertical), Color.black);
        Debug.DrawLine(new Vector3(screen_size_horizontal, screen_size_vertical), new Vector3(-screen_size_horizontal, screen_size_vertical), Color.black);
        Debug.DrawLine(new Vector3(-screen_size_horizontal, screen_size_vertical), new Vector3(-screen_size_horizontal, -screen_size_vertical), Color.black);
        Debug.DrawLine(new Vector3(-screen_size_horizontal, -screen_size_vertical), new Vector3(screen_size_horizontal, -screen_size_vertical), Color.black);

    }
}
