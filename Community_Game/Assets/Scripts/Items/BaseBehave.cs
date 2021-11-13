using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehave : MonoBehaviour
{

    EndGame gameEnder; //EndGame Script
    BaseHealth health;

    private void Start()
    {
        gameEnder = GameObject.Find("GameManager").GetComponent<EndGame>();
        health = GameObject.Find("HealthBar").GetComponent<BaseHealth>();
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            health.decreaseHealth();
            Destroy(collision.gameObject);
            if (health.getHealth() == 0)
            {
                gameEnder.GameOver(); //end game when health zero
            }
        }
    }

 

    /*Helper function*/
    
}
