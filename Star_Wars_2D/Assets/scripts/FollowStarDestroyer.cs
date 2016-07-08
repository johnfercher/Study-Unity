using UnityEngine;
using System.Collections;

public class FollowStarDestroyer : UBackground
{

    // Use this for initialization
    void Start()
    {
        //camera = GetComponent<Camera>();
        target = GameObject.Find("Main");
        init();

        speedFollow = 5.0f;
        translate.x = -5.0f;
        translate.y = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }
}
