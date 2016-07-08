using UnityEngine;
using System.Collections;

public class FollowStarDestroyerII : UBackground
{

    // Use this for initialization
    void Start()
    {
        //camera = GetComponent<Camera>();
        target = GameObject.Find("Main");
        init();

        speedFollow = 10.0f;
        translate.x = -2.0f;
        translate.y = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }
}
