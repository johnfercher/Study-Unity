using UnityEngine;
using System.Collections;

public class FollowDeathStar : UBackground
{

    // Use this for initialization
    void Start()
    {
        //camera = GetComponent<Camera>();
        target = GameObject.Find("Main");
        init();

        speedFollow = 20.0f;
        translate.x = 18.0f;
        translate.y = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }
}
