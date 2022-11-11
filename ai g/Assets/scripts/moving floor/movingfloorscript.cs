using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingfloorscript : MonoBehaviour {

    [SerializeField]
    private bool moveX, moveY, moveZ;
    [SerializeField]
    private float speed;
	
	void Update () {
        moveplatform();
		
	}
    void moveplatform()
    {
        if(moveX)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
    }
    void OnTriggerEnter(Collider target)
    { 
      if(target.gameObject.tag == "floor")
        {
            speed *= -1;
        }
    }
}
