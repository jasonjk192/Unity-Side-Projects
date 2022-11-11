using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyball : MonoBehaviour {

    public Transform balltarget;
    private Vector3 ballposiitionDirection;
    private bool canAttack, readytoAttack;

    [HideInInspector]
    public bool stunned;

    public Rigidbody mybody;
    public RaycastHit ballhit;

    void Awake ()
    {
        mybody = GetComponent<Rigidbody>();
	}
	
	
	void Update ()
    {
        checkifcanAttack();	
	}
    void FixedUpdate()
    {
        attack();   
    }
    void getballTarget(Transform target) //gets the position of our ball from the other script after collision
    {
        balltarget = target;
    }
    void canAttackToggle(bool canAttack)
    {
        this.canAttack = canAttack;
    }
    void checkifcanAttack()
    {
        if(canAttack && !stunned && (mybody.velocity.sqrMagnitude <= 0.11f))
        {
            ballposiitionDirection = balltarget.position - transform.position;
        }
        if(Physics.Raycast(transform.position,ballposiitionDirection,out ballhit, 25)) //draws a line from  tarnsfom.position in the direction of ballpositiondirection of length 25 
        {
            if(ballhit.transform.tag=="ball")
            {
                readytoAttack = true;
            }
        }
    }
    void attack()
    {
        if(readytoAttack)
        {
            mybody.AddForce(ballposiitionDirection * 18f);
            readytoAttack = false;
        }
    }
}
