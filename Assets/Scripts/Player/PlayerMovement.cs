using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{ 
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer BattleKid;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundedLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    private object hitInfo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        BattleKid = GetComponent<SpriteRenderer>();

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundedLayer);

        if (isGrounded)
        {
            if (verticalInput > 0)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);
            }
        }

        if (Input.GetButton("Fire1"))
        {
           anim.SetBool("Shoot", true);
        }
        else
        {
            anim.SetBool("Shoot", false);
        }


        Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);

        if (BattleKid.flipX && horizontalInput > 0 || !BattleKid.flipX && horizontalInput < 0)
            BattleKid.flipX = !BattleKid.flipX;

        
    }

   // private void OnTriggerEnter2D(Collider2D collision)
   // {
    //    if (collision.gameObject.tag =="PowerUp")
   //     {
   //       Destroy(gameObject);
  //      }
  //  }

}
