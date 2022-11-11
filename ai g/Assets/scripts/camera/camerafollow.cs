using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {

    public Transform ball;

    public float distance=50f;
    public float xspeed=250f;
    public float yspeed=120f;
    public float yminlimit=0f;
    public float ymaxlimit=80f;
    public Quaternion rotation;
    public Vector3 position;
    public float xAngle = 0f, yAngle = 0f;
    public float angleMultiplier = 0.02f;
    private bool snapcamera;
    Vector3 rot;
    /*void Awake()
    {
        ball = GameObject.Find("ball").transform;
    }*/

    // Use this for initialization
    void Start () {
        rot = transform.eulerAngles;
        yAngle = rot.y;
        xAngle = rot.x;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		
	}

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            snapcamera = true;
        }
    }// Update is called once per frame

    private void LateUpdate()
    {
        
        
       if(ball)
        {
            xAngle += Input.GetAxis("Mouse X")* xspeed*angleMultiplier;
            yAngle += Input.GetAxis("Mouse Y") * yspeed * angleMultiplier;
            yAngle=ClampAngle(yAngle, yminlimit, ymaxlimit);
            if(snapcamera)
            {
                /*if(transform.eulerAngles.y <=225f && transform.eulerAngles.y > 135f)
                {
                    xAngle = 180f;
                }
                else if(transform.eulerAngles.y<=135 && transform.eulerAngles.y > 45f)
                {
                    xAngle = 90f;
                }
                else if(transform.eulerAngles.y<=315f && transform.eulerAngles.y > 225f)
                {
                    xAngle = 275f;
                }
                else
                {*/
                    xAngle = rot.x;
                //}
                snapcamera = false;
            }
            rotation = Quaternion.Euler(yAngle, xAngle, 0);
        
            position = rotation * new Vector3(0, 0, -distance/*distance of camera from the ball*/) + ball.position;
            transform.rotation = rotation;
            transform.position = position;

        }
    }
     float ClampAngle(float angle,float min,float max)
     {
        
        if(angle<-360f)
        {
            angle += 360f;
        }
        if(angle>360f)
        {
            angle -= 360f;
        }
        return Mathf.Clamp(angle,min,max);
     }
}
