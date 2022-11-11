using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resizeball : MonoBehaviour {

    private Vector3 smallball_scale = new Vector3(1.5f, 1.5f, 1.5f);
    private Vector3 mediumball_scale = new Vector3(3f, 3f, 3f);
    private Vector3 largeball_scale = new Vector3(6f,6f, 6f);

    private float smallball_mass = 0.5f;
    private float mediumball_mass = 1f;
    private float largeball_mass = 1.2f;

    private bool removeresizer;
    private bool removeresizecollide;
    private bool ballresized;

    private string smallBall = "SmallBall";
    private string largeBall = "LargeBall";
    private string mediumBall = "MediumBall";
    // ||
    void Awake ()
    {
        if(gameObject.name==smallBall ||gameObject.name==mediumBall || gameObject.name==largeBall)
        {
            removeresizer = false;
        }
        else
        {
            removeresizer = true;

        }
		
	}
    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "ball")
        {
            if (gameObject.tag == smallBall)
            {
                if (target.gameObject.transform.localScale != smallball_scale)
                {
                    target.gameObject.transform.localScale = smallball_scale;
                    target.gameObject.GetComponent<Rigidbody>().mass = smallball_mass;
                    ballresized = true;
                }

            }
            if (gameObject.tag == mediumBall)
            {
                if (target.gameObject.transform.localScale != mediumball_scale)
                {
                    target.gameObject.transform.localScale = mediumball_scale;
                    target.gameObject.GetComponent<Rigidbody>().mass = mediumball_mass;
                    ballresized = true;
                }
            }
            if (gameObject.tag == largeBall)
            {
                if (target.gameObject.transform.localScale != largeball_scale)
                {
                    target.gameObject.transform.localScale = largeball_scale;
                    target.gameObject.GetComponent<Rigidbody>().mass = largeball_mass;
                    ballresized = true;
                }
            }
            if(ballresized)
            {
                if (removeresizer)
                {
                    removeresizecollide = true;
                }
            
                ballresized = false;
                target.gameObject.GetComponent<ballsound>().PlayPickUpSound();
            }
            if(removeresizecollide)
            {
                gameObject.SetActive(false);
                
            }

        }

     }
	
	

}
