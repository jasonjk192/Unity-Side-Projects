using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wrongway : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        GetComponent<MeshRenderer>().enabled = false;
		
	}
	void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag == "ball" )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
      
}
