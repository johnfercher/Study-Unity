using UnityEngine;
using System.Collections;

public class FollowStarDestroyerIII : UBackground
{

    // Use this for initialization
    void Start()
    {
        //camera = GetComponent<Camera>();
        target = GameObject.Find("Main");
        init();

        speedFollow = 15.0f;
        translate.x = -4.0f;
        translate.y = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }
}
