using UnityEngine;
using System.Collections;

public class MainCharacter : UObject {
    protected bool resized, key_resized;
    // Use this for initialization
    void Start()
    {
        init();
        is_static = false;

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();

        rigidbody.gravityScale = 20;
        rigidbody.mass = 1;
    }

    // Update is called once per frame
    void Update()
    {
        handle_inputs();
        handle_inputs_main_char();

        control();
        reset_control();
    }

    void handle_inputs_main_char()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 1"))
        {
            resized = !resized;
            key_resized = true;
        }
    }
 
    void control()
    {
        if (resized && key_resized)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x / 2.0f;
            scale.y = scale.y / 2.0f;
            transform.localScale = scale;
            scalar_velocity = 25.0f;
        }
        else
           if (!resized && key_resized)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * 2.0f;
            scale.y = scale.y * 2.0f;
            transform.localScale = scale;
            scalar_velocity = 12.0f;
        }

        if (rigidbody.position.y < -40)
        {
            rigidbody.position = Vector3.zero;
            rigidbody.velocity = Vector3.zero;
        }
    }

    protected void reset_control()
    {
        key_resized = false;
    }
}
