using UnityEngine;
using System.Collections;

public class UBackground : MonoBehaviour{
    protected GameObject target;
    protected float speedMovement;
    protected float speedFollow;
    protected Vector2 translate;
    protected Vector2 movement;
    protected Vector2 min_pos, max_pos;
    private bool way;
    
    protected void init()
    {
        translate = Vector2.zero;
        way = true;
        speedMovement = 0.005f;
        max_pos = new Vector2(20, 20);
        min_pos = new Vector2(0, 0);
    }

    protected void move()
    {
        if (way)
        {
            movement = transform.position;
            movement.x = movement.x + speedMovement;
            transform.position = movement;

            if (transform.position.x > max_pos.x)
            {
                way = false;
            }
        }
        else
        {
            movement = transform.position;
            movement.x = movement.x - speedMovement;
            transform.position = movement;

            if (transform.position.x < min_pos.x)
            {
                way = true;
            }
        }

    }

    protected void follow()
    {
        //if (target) {
            transform.position = new Vector3(target.transform.position.x - (target.transform.position.x/(speedFollow*2.0f)) + translate.x, target.transform.position.y - (target.transform.position.y/(speedFollow*8.0f)) + translate.y, target.transform.position.z);
        //}
    }
}
