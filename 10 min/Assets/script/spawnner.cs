using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnner : MonoBehaviour {

    public float Spawnrate = 1f;

    public GameObject hexa;

    private float nextSpawnTime=0f;

    
	
	
	void Update ()
    {
	if(Time.time>nextSpawnTime)
        {
            Instantiate(hexa, Vector3.zero, Quaternion.identity);
            nextSpawnTime = Time.time + 1f / Spawnrate;
        }
	}
}
