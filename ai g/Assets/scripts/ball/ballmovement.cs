using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ballmovement : MonoBehaviour
{

    private string direction = "";
    private string directionLastFrame = "";
    
    public int onfloorTracker=0;
    public bool fullspeed = true;

    //speed variables
    private int floorspeed = 500;
    private int airspeed = 80;
    private float air_drag = 2.23f;
    private float airspeed_diagonal = 23f;
    private float floor_drag = 2.233f;
    private float delta = 50f;

    //camera variables
    private Vector3 cameraRelative_right;
    private Vector3 cameraRelative_up;
    private Vector3 cameraRelative_down;
    private Vector3 cameraRelative_up_right;
    private Vector3 cameraRelative_up_left;

    //velocity and magnitude variables
    private Vector3 x_vel;
    private Vector3 z_Vel;
    private float x_speed;
    private float z_speed;

    //axis
    public string yaxis = "Vertical";
    public string xaxis = "Horizontal";

    public  Rigidbody rb;
    private Camera maincamera;
    public string blah = "";
    public string elah = "";
    public string alah = "";


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        maincamera = Camera.main;
    }


    void Start()
    {


    }


    void Update()
    {
        UpdateCameraRelativePosition();
        fullspeedcontroller();
        getdirection();
        moveball();
        ballfalldown();

    }
    void LateUpdate()
    {
        directionLastFrame = direction;
        
    }
    


    IEnumerable FullSpeedTime()
    {
        yield return new WaitForSeconds(0.07f);
        fullspeed = true;
    }
    void FixedUpdate()
    {
        
    }
    void getdirection()
    {
        direction = "";

        if (Input.GetAxis(yaxis) > 0)
        {
            direction += "up";
            blah = direction;
            elah = directionLastFrame;
        }
        else if (Input.GetAxis(yaxis) < 0)
        {
            direction += "down";
            blah = direction;
            elah = directionLastFrame;
        }

        if (Input.GetAxis(xaxis) < 0)
        {
            direction += "right";
            blah = direction;
            elah = directionLastFrame;
        }
        else if (Input.GetAxis(xaxis) > 0)
        {
            direction += "left";
            blah = direction;
            elah = directionLastFrame;
        }

    }
    void moveball()
    {
        switch (direction)
        {
            case "upright":
                
                if (onfloorTracker > 0)
                {
                    if (fullspeed)
                    {
                       
                        rb.AddForce(floorspeed * cameraRelative_up_right * Time.fixedDeltaTime);
                    }
                    else if(!fullspeed)
                    {
                       
                        rb.AddForce((floorspeed - 75f) * cameraRelative_up_right * Time.fixedDeltaTime);
                    }
                }
                else if (onfloorTracker == 0)
                {
                    if(z_Vel.normalized == cameraRelative_up)
                    {
                        if(z_speed <(airspeed-airspeed_diagonal-0.1f))
                        {
                            rb.AddForce(10.6f * cameraRelative_up * Time.fixedDeltaTime*delta); 
                        
                        }
                    }
                    else
                    {
                        rb.AddForce(10.6f * cameraRelative_up * Time.fixedDeltaTime*delta);
                    }
                    if(x_vel.normalized == cameraRelative_right)
                    {
                        if(x_speed < (airspeed-airspeed_diagonal-0.1f))
                        {
                            rb.AddForce(10.6f * cameraRelative_right * Time.fixedDeltaTime*delta);
                        }
                    }
                    else
                    {
                        rb.AddForce(10.6f * cameraRelative_right * Time.fixedDeltaTime*delta);
                    }

                }
                break;
            case "upleft":
                if (onfloorTracker > 0)
                {
                    if (fullspeed)
                    {
                        rb.AddForce(floorspeed * cameraRelative_up_left * Time.fixedDeltaTime);
                    }
                    else
                    {
                        rb.AddForce((floorspeed-75f) * cameraRelative_up_left * Time.fixedDeltaTime);
                    }
                }
                else if(onfloorTracker == 0)
                {
                    if(z_Vel.normalized==cameraRelative_up)
                    {
                        if(z_speed <(airspeed-airspeed_diagonal-0.1f))
                        {
                            rb.AddForce(10.6f * cameraRelative_up * Time.fixedDeltaTime*delta);
                        }
                    }
                    else
                    {
                        rb.AddForce(10.6f * cameraRelative_up * Time.fixedDeltaTime*delta);
                    }
                    if(x_vel == -(cameraRelative_right))
                    {
                        if(x_speed < (airspeed-airspeed_diagonal-0.1f))
                        {
                            rb.AddForce(10.6f * -cameraRelative_right * Time.fixedDeltaTime*delta);
                        }
                    }
                    else
                    {
                        rb.AddForce(10.6f * -cameraRelative_right * Time.fixedDeltaTime * delta);
                    }
                }
                break;
            case "downright":

                if (onfloorTracker > 0)
                {
                    if (fullspeed)
                    {

                        rb.AddForce(floorspeed * -cameraRelative_up_left * Time.fixedDeltaTime);
                    }
                    else if (!fullspeed)
                    {

                        rb.AddForce((floorspeed - 75f) * -cameraRelative_up_left * Time.fixedDeltaTime);
                    }
                }
                else if (onfloorTracker == 0)
                {
                    if (z_Vel.normalized == -cameraRelative_up)
                    {
                        if (z_speed < (airspeed - airspeed_diagonal - 0.1f))
                        {
                            rb.AddForce(10.6f * -cameraRelative_up * Time.fixedDeltaTime * delta);

                        }
                    }
                    else
                    {
                        rb.AddForce(10.6f * -cameraRelative_up * Time.fixedDeltaTime * delta);
                    }
                    if (x_vel.normalized == cameraRelative_right)
                    {
                        if (x_speed < (airspeed - airspeed_diagonal - 0.1f))
                        {
                            rb.AddForce(10.6f * cameraRelative_right * Time.fixedDeltaTime * delta);
                        }
                    }
                    else
                    {
                        rb.AddForce(10.6f * cameraRelative_right * Time.fixedDeltaTime * delta);
                    }

                }
                break;
            case "downleft":

                if (onfloorTracker > 0)
                {
                    if (fullspeed)
                    {

                        rb.AddForce(floorspeed * -cameraRelative_up_right * Time.fixedDeltaTime);
                    }
                    else if (!fullspeed)
                    {

                        rb.AddForce((floorspeed - 75f) * -cameraRelative_up_right * Time.fixedDeltaTime);
                    }
                }
                else if (onfloorTracker == 0)
                {
                    if (z_Vel.normalized == -cameraRelative_up)
                    {
                        if (z_speed < (airspeed - airspeed_diagonal - 0.1f))
                        {
                            rb.AddForce(10.6f * -cameraRelative_up * Time.fixedDeltaTime * delta);

                        }
                    }
                    else
                    {
                        rb.AddForce(10.6f * -cameraRelative_up * Time.fixedDeltaTime * delta);
                    }
                    if (x_vel.normalized == -cameraRelative_right)
                    {
                        if (x_speed < (airspeed - airspeed_diagonal - 0.1f))
                        {
                            rb.AddForce(10.6f * -cameraRelative_right * Time.fixedDeltaTime * delta);
                        }
                    }
                    else
                    {
                        rb.AddForce(10.6f * -cameraRelative_right * Time.fixedDeltaTime * delta);
                    }

                }
                break;
            case "right":

                if (onfloorTracker > 0)
                {
                    if (fullspeed)
                    {
                        rb.AddForce(floorspeed * cameraRelative_right * Time.fixedDeltaTime);
                    }
                    else 
                    {

                        rb.AddForce((floorspeed - 75f) * cameraRelative_right * Time.fixedDeltaTime);
                    }
                }
                else if (onfloorTracker == 0)
                {
                  
                        if (x_speed < airspeed) 
                        {
                            rb.AddForce(10.6f * cameraRelative_right * Time.fixedDeltaTime * delta);

                        }
                        else if(z_speed> 0.1f)
                        {
                            if (z_Vel.normalized == cameraRelative_up)
                            {
                               rb.AddForce(10.6f * -cameraRelative_up * Time.fixedDeltaTime * delta);

                            }
                            else if(z_Vel.normalized == -cameraRelative_up)
                            {
                               rb.AddForce(10.6f * cameraRelative_up * Time.fixedDeltaTime * delta);
                            }  
                        }
                }
                break;
            case "left":
                if (onfloorTracker > 0)
                {
                    if (fullspeed)
                    {
                        rb.AddForce(floorspeed * -cameraRelative_right * Time.fixedDeltaTime);
                    }
                    else
                    {

                        rb.AddForce((floorspeed - 75f) * -cameraRelative_right * Time.fixedDeltaTime);
                    }
                }
                else if (onfloorTracker == 0)
                {

                    if (x_speed < airspeed)
                    {
                        rb.AddForce(10.6f * -cameraRelative_right * Time.fixedDeltaTime * delta);

                    }
                    else if (z_speed > 0.1f)
                    {
                        if (z_Vel.normalized == cameraRelative_up)
                        {
                            rb.AddForce(10.6f * cameraRelative_up * Time.fixedDeltaTime * delta);

                        }
                        else if (z_Vel.normalized == -cameraRelative_up)
                        {
                            rb.AddForce(10.6f * -cameraRelative_up * Time.fixedDeltaTime * delta);
                        }
                    }
                }
                break;
            case "down":
                if (onfloorTracker > 0)
                {
                    if (fullspeed)
                    {
                        rb.AddForce(floorspeed * -cameraRelative_up * Time.fixedDeltaTime);
                    }
                    else
                    {

                        rb.AddForce((floorspeed - 75f) * -cameraRelative_up * Time.fixedDeltaTime);
                    }
                }
                else if (onfloorTracker == 0)
                {

                    if (z_speed < airspeed)
                    {
                        rb.AddForce(10.6f * -cameraRelative_up * Time.fixedDeltaTime * delta);

                    }
                    else if (x_speed > 0.1f)
                    {
                        if (x_vel.normalized == cameraRelative_right) //velocity on the x-axis is towards the rigth 
                        {
                            rb.AddForce(10.6f * cameraRelative_right * Time.fixedDeltaTime * delta);

                        }
                        else if (x_vel.normalized == -cameraRelative_right) //velocity on the x-axis is towards the left
                        {
                            rb.AddForce(10.6f * -cameraRelative_right * Time.fixedDeltaTime * delta);
                        }
                    }
                }

                break;
            case "up":
                if (onfloorTracker > 0)
                {
                    if (fullspeed)
                    {
                        rb.AddForce(floorspeed * cameraRelative_up * Time.fixedDeltaTime);
                    }
                    else
                    {

                        rb.AddForce((floorspeed - 75f) * cameraRelative_up * Time.fixedDeltaTime);
                    }
                }
                else if (onfloorTracker == 0)
                {

                    if (z_speed < airspeed)
                    {
                        rb.AddForce(10.6f * cameraRelative_up * Time.fixedDeltaTime * delta);

                    }
                    else if (x_speed > 0.1f)
                    {
                        if (x_vel.normalized == cameraRelative_right)
                        {
                            rb.AddForce(10.6f * -cameraRelative_right * Time.fixedDeltaTime * delta);

                        }
                        else if (x_vel.normalized == -cameraRelative_right)
                        {
                            rb.AddForce(10.6f * cameraRelative_right * Time.fixedDeltaTime * delta);
                        }
                    }
                }

                break;
        }


    }
    public void UpdateCameraRelativePosition()
    {
        cameraRelative_right = maincamera.transform.TransformDirection(Vector3.right);// transforms camera's rigth to world space units
        cameraRelative_up = maincamera.transform.TransformDirection(Vector3.forward);//up of ball is forward in comparision to the camera Vector3.forward=Vector3(0,0,1)
        cameraRelative_up.y = 0f;
        cameraRelative_up = cameraRelative_up.normalized; //makes the magnitude of a vector 1
        cameraRelative_up_right = (cameraRelative_up + cameraRelative_right);
        cameraRelative_up_right = cameraRelative_up_right.normalized;
        cameraRelative_up_left = (cameraRelative_up - cameraRelative_right);
        cameraRelative_up_left = cameraRelative_up_left.normalized;


    }
    void dragadjustairspeed()
    {
        if(onfloorTracker>0)
        {
            rb.drag = floor_drag;
        }
        else
        {
            x_vel=Vector3.Project(rb.velocity,cameraRelative_right);
            z_Vel = Vector3.Project(rb.velocity, cameraRelative_up);
            x_speed = x_vel.magnitude;
            z_speed = z_Vel.magnitude;
            rb.drag = air_drag;
        }
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "floor")
        {
            onfloorTracker ++;


        }
    }
    void OnCollisionExit(Collision target)
    {
        if (target.gameObject.tag == "floor")
        {
            onfloorTracker -- ;

        }
    }
    void ballfalldown()
    {
        if(gameObject.transform.position.y < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }      
    
    void fullspeedcontroller()
    {
        if (directionLastFrame != direction)
        {
            if (direction == "")
            {
                StopCoroutine("FullSpeedTime");
                fullspeed = false;
            }
            else if (directionLastFrame == "")
            {
                StartCoroutine("FullSpeedTime");
            }

        }
    }
}

