using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehave : MonoBehaviour
{
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(this.gameObject);
        }


        if (collision.gameObject.tag.Equals("Weapon"))
        {
            Destroy(this.gameObject);
        }
    }


}
