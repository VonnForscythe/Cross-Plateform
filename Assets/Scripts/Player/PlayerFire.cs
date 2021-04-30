using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerFire : MonoBehaviour

{
    SpriteRenderer Player;
    Animator anim;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;
    public Projectile projectilePrefab;

    void Start()
    {

        Player = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


        // if (projectileSpeed <= 0)
        //     projectileSpeed = 7.0f;



        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Unity values not set");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Shoot", true);
        }

    }

    void FireProjectile()
    {
        if (Player.flipX)
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.speed = projectileSpeed = -15.0f;
        }
        else
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.speed = projectileSpeed = 15.0f;
        }
    }

    void ResetFire()
    {

        anim.SetBool("Shoot", false);

    }

}
