using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehave : MonoBehaviour
{
    /************PLAYER(S)************/

    private PlayerSelect PlayerDetails;
    private void Start()
    {
        PlayerDetails = GameObject.Find("GameManager").GetComponent<PlayerSelect>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag.Equals("Enemy")))
        {
            if (!this.gameObject.tag.Equals("Weapon"))
            {
                PlayerDetails.removePlayer(this.gameObject);
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Lava"))
        {
            PlayerDetails.removePlayer(this.gameObject);
            Destroy(this.gameObject);
        }
    }


}
