using UnityEngine;
using System.Collections;

public class UObject : MonoBehaviour {
    public Rigidbody2D rigidbody;
    public Animator animator;
    public CircleCollider2D circleCollider;
    private LayerMask whatIsGround;

    protected bool is_static;
    protected bool grounded;
    protected bool jump;
    protected bool boost_jump;
    protected float theta_l3, theta_l32;

    protected float scalar_velocity;
    protected float scalar_amp_jump;
    protected Vector2 velocity;

    protected void init()
    {
        boost_jump = false;
        jump = false;
        is_static = true;
        grounded = true;
        scalar_velocity = 12.0f;
        scalar_amp_jump = 2200.0f;
    }

    protected void handle_inputs()
    {
        theta_l3 = Mathf.Abs(Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
       
        if (theta_l3 < 1.1f)
        {
            theta_l3 = 1.1f;
        }

        Debug.Log(theta_l3);
        theta_l32 = Mathf.Abs(Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")));
        is_grounded();

        velocity = new Vector2(Input.GetAxis("Horizontal")*scalar_velocity, 0);

        if (!jump && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("joystick button 0"))
        {
            jump = true;
        }

        control();
        reset_control();
    }

    private void control()
    {
        if (!is_static) { 
            if (!grounded)
            {
                animator.SetBool("jump", true);
                velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
                rigidbody.AddForce(new Vector2(0, -rigidbody.gravityScale));
                //velocity = new Vector2(velocity.x * Mathf.Abs(theta_l3)*0.7f, velocity.y *0.7f);
            }
            else
            {                         
                if (jump)
                {
                    //velocity = new Vector2(Input.GetAxis("Horizontal") * Mathf.Abs(theta_l3) * scalar_velocity, velocity.y * Mathf.Abs(theta_l3));
                    rigidbody.AddForce(new Vector2(scalar_velocity + 5 + Input.GetAxis("Horizontal") * scalar_velocity, scalar_amp_jump + Input.GetAxis("Vertical")*scalar_amp_jump*0.3f));
                    if (boost_jump)
                    {
                        rigidbody.AddForce(new Vector2(scalar_velocity + 5 + Input.GetAxis("Horizontal") * scalar_velocity, scalar_amp_jump + Input.GetAxis("Vertical")*scalar_amp_jump*0.3f));
                    }
                }
                animator.SetBool("jump", false);
            }

            rigidbody.velocity = velocity;
        }
    }

    protected void reset_control()
    {
        jump = false;
        boost_jump = false;
    }

    protected void is_grounded()
    {
        grounded = false;

        if (rigidbody.velocity.y <= 0)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, circleCollider.radius-1);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    grounded = true;
                }

                if (colliders[i].gameObject.name == "floor_jump")
                {
                    boost_jump = true;
                }
            }
        }
    }
}
