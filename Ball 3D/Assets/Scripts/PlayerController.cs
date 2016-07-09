using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private bool grounded;
    private bool jump;
    private bool super_jump;
    private float move_speed, move_jump;
    private Vector3 movement;
    private int mode;

    private Rigidbody rb;
    public Text win_text;
	// Use this for initialization
	void Start () {
        super_jump = false;
        mode = 0;
        grounded = true;
        jump = false;
        move_speed = 8.0f;
        move_jump = 700.0f;
        movement = Vector3.zero;

        rb = GetComponent<Rigidbody>();
        win_text.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        HandleInputs();
    }

    void FixedUpdate()
    {
        ApplyForces();
    }

    void HandleInputs()
    {
        if (grounded) { 
            movement.x = Input.GetAxis("Horizontal");
            //movement.z = Input.GetAxis("Vertical");

            if (!jump && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
            {
                jump = true;
            }
        }

        if (Input.GetKeyDown("joystick button 1"))
        {
            if (mode == 0)
                mode = 1;
            else
                mode = 0;
        }
    }

    void ApplyForces()
    {
        if (mode == 0) { 
            // Apply Movement from Inputs
            rb.velocity = new Vector3(movement.x * move_speed, rb.velocity.y, 0.0f);

            // Apply Jump, Player must be grounded
            if (jump)
            {
                rb.AddForce(new Vector3(move_speed + 5 + Input.GetAxis("Horizontal") * move_speed, move_jump + Input.GetAxis("Vertical") * move_jump * 0.3f, 0.0f));
                if (super_jump)
                {
                    rb.AddForce(new Vector3(move_speed + 5 + Input.GetAxis("Horizontal") * move_speed, move_jump + Input.GetAxis("Vertical") * move_jump * 0.3f, 0.0f));
                }
                //rb.AddForce(new Vector3(0.0f, move_jump, 0.0f));
                jump = false;
            }
        }else
        if (mode == 1)
        {
            // Apply Movement from Inputs
            rb.velocity = new Vector3(0.0f, rb.velocity.y, -movement.x * move_speed);

            // Apply Jump, Player must be grounded
            if (jump)
            {
                rb.AddForce(new Vector3(0.0f, move_jump + Input.GetAxis("Vertical") * move_jump * 0.3f, move_speed + 5 + Input.GetAxis("Horizontal") * move_speed));
                if (super_jump)
                {
                    rb.AddForce(new Vector3(0.0f, move_jump + Input.GetAxis("Vertical") * move_jump * 0.3f, move_speed + 5 + Input.GetAxis("Horizontal") * move_speed));
                }
                //rb.AddForce(new Vector3(0.0f, move_jump, 0.0f));
                jump = false;
            }
        }

        // Apply Gravity
        rb.AddForce(new Vector3(0.0f, -1000.0f * Time.deltaTime, 0.0f));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor_Jump"))
        {
            super_jump = true;
            Debug.Log("super jump");
        }else {
            super_jump = false;
        }

        if (collision.gameObject.CompareTag("Floor_Finish"))
        {
            win_text.text = "Stage 1: \n You Win !";
        }
        else
        {
            super_jump = false;
        }
        grounded = true;
            //Debug.Log("Grounded");
        //}
    }

    void OnCollisionExit(Collision collision)
    {
        //grounded = true;
        //if (collision.gameObject.CompareTag("Floor"))
        //{
            grounded = false;
        //}

        if (collision.gameObject.CompareTag("Floor_Jump"))
        {
            super_jump = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor_Jump"))
        {
            super_jump = true;
            Debug.Log("super jump");
        }
        else
        {
            super_jump = false;
        }
        //if (collision.gameObject.CompareTag("Floor"))
        //{
        grounded = true;
        //}
    }

}

