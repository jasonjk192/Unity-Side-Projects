using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cratePhysicsScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Player")|| collision.gameObject.tag.Equals("Enemy"))
        {
            GetComponent<Rigidbody>().AddForce(collision.transform.forward * 100);
            GetComponent<Rigidbody>().AddForce(transform.up * 100);
        }
            
    }
}
