using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoints;
    public BossHealthBar healthBar;

    GameObject canvas;
    ScoreBehaviour currentScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "PlayerProjectile")
        {
            healthPoints -= 1.0f;
            healthBar.SetHealth(healthPoints);
            currentScore.value += 10;

            if (healthPoints <= 0.0f)
            {
                Destroy(gameObject);
                currentScore.value += 1000;

            }

        }
    }
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        currentScore = canvas.GetComponent<ScoreBehaviour>();

        healthBar.SetMaxHealth(healthPoints);
    }

    void Update()
    {
        
    }
}
