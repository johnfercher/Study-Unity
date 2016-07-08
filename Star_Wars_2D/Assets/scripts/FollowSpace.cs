using UnityEngine;
using System.Collections;

public class FollowSpace: UBackground
{

    // Use this for initialization
    void Start()
    {
        speedFollow = 90.0f;
        //camera = GetComponent<Camera>();
        target = GameObject.Find("Main");
        init();
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }
}
