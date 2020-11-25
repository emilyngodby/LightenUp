using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Move : MonoBehaviour
{
    public Entity player;
    private Rigidbody2D rb;
    private float xDirection;
    private float yDirection;
    private float move = 5f;
    private float jump = 18f;
    private bool canDoubleJump = false;

    public Vector2 currentVelocity = Vector2.zero;

    Animator anim;

    private BoxCollider2D boxCollider2D;
    public LayerMask platformLayerMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        //xDirection = CrossPlatformInputManager.GetAxis("Horizontal") * move;
        //rb.velocity = new Vector2(xDirection, rb.velocity.y);
    }
    private void FixedUpdate()
    {
        xDirection = CrossPlatformInputManager.GetAxis("Horizontal") * move;
        rb.velocity = new Vector2(xDirection, rb.velocity.y);

        currentVelocity = rb.velocity;

        if(currentVelocity.x == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }
    }
    private bool OnGround()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down * .1f, platformLayerMask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }

    /*public void JumpButton()
    {
        if(rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jump;
            canDoubleJump = true;
        }
        if(canDoubleJump)
        {
            rb.velocity = Vector2.up * jump;
            canDoubleJump = false;
        }

    }*/

    public void OnPointerDown()
    {
        if (rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jump;
            canDoubleJump = true;
        }
    }

    public void OnPointerUp()
    {
        if (canDoubleJump)
        {
            rb.velocity = Vector2.up * jump;
            canDoubleJump = false;
        }
    }
}
