using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    public float speed = 8f;
    private float speedfin;
    private float sprint = 1.7f;
    public float jumpingPower = 5f;
    public static bool isFacingRight = true;


    public Transform firepoint;
    public GameObject defaultShot,defaultShot2;
    public Vector2 bulletdirection;

    public Animator anim;
    private bool checkjump,checkshoot;


    public float defaultSpeed;

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        anim.SetFloat("speed", Mathf.Abs(horizontal));
        if(checkjump != true)
        {
            anim.SetBool("Jump", false);
        }
        if(checkshoot != true)
        {
            anim.SetBool("Attack", false);
        }
        
    }

    private void FixedUpdate()
    {    
        rb.velocity = new Vector2(horizontal * speedfin, rb.velocity.y);
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.SetBool("Jump", true);
            checkjump = true;
        }

        
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed )
        {
            if (isFacingRight)
            {
                Instantiate(defaultShot, new Vector3(firepoint.position.x,firepoint.position.y,0f), transform.rotation);

            }
            else
            {
                Instantiate(defaultShot2, firepoint.position, transform.rotation);
                
            }
            anim.SetBool("attack", true);
            checkshoot = true;
            
        }
    }

    void attackfalse()
    {
        anim.SetBool("attack", false);
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            speedfin = speed * sprint;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        speedfin = speed;
        horizontal = context.ReadValue<Vector2>().x;
        
    }
     



}