using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;

    private Rigidbody rb;
    
    // Called before every render frame
    void Update()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Called before every step simulation
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}
