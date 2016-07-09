using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public int mode;

    private Vector3 plataformOffsetPos;
    private Quaternion plataformOffsetRotation;

    private Vector3 rdPersonOffsetPos;
    private Quaternion rdPersonOffsetRotation;

    // Use this for initialization
    void Start()
    {
        mode = 0;

        // plataform view
        plataformOffsetPos = new Vector3(0.0f, 0.5f, -7.0f);
        plataformOffsetRotation.eulerAngles = new Vector3(0.0f, 00.0f, 0.0f);

        // 3rd person view
        rdPersonOffsetPos = new Vector3(-5.0f, 5.0f, 0.0f);
        rdPersonOffsetRotation.eulerAngles = new Vector3(45.0f, 90.0f, 0.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            if (mode == 0)
                mode = 1;
            else
                mode = 0;
        }

        if (mode == 0)
        {
            transform.position = player.transform.position + plataformOffsetPos;
            transform.rotation = plataformOffsetRotation;
        }
        else
        if (mode == 1)
        {
            transform.position = player.transform.position + rdPersonOffsetPos;
            transform.rotation = rdPersonOffsetRotation;
        }
    }
}
