using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    void Start()
    {
       
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.queriesStartInColliders = false;
  //    Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
}
