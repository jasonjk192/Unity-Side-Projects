using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float JumpForce = 10f;
    public Rigidbody2D mybody;
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mybody.velocity = Vector2.up * JumpForce;
        }

		
	}
}
