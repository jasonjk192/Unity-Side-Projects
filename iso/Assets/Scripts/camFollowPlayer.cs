using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollowPlayer : MonoBehaviour {

    [SerializeField]
    GameObject player;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cpos = player.transform.position;
        cpos.y = 20;
        cpos.x -= 25;
        cpos.z -= 25;
        transform.position = cpos;
	}
}
