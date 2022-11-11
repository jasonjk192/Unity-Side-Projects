using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float movespeed = 600;
    public float horizontal=0f;
    public void LeftClick()
    {
        horizontal = -.4f;
        transform.RotateAround(Vector3.zero, Vector3.forward, -movespeed * Time.fixedDeltaTime * horizontal);
    }
    public void RigthClick()
    {
        horizontal = .4f;
        transform.RotateAround(Vector3.zero, Vector3.forward, -movespeed * Time.fixedDeltaTime * horizontal);
    }
    private void FixedUpdate()
    {
        
    }
}
