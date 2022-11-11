using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostscript : MonoBehaviour {

    private float force = 150f;
	public void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag=="ball")
        {
            target.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward *(-force) , ForceMode.Impulse);//impulse is force applied rigth away not over time
        }
    }
}
