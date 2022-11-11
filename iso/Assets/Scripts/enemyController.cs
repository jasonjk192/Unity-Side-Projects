using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    [SerializeField]
    GameObject player;
    [SerializeField]
    float moveSpeed = 4f;
    [SerializeField]
    float rotSpeed = 4f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    float vel;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        vel = 0;
	}
	
	void Update () {
        if (transform.position.y < -40)
            Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        if (IsGrounded())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
            Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            vel = Vector3.Magnitude(GetComponent<Rigidbody>().velocity);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            if (Vector3.Magnitude(GetComponent<Rigidbody>().velocity) > moveSpeed)
                GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, moveSpeed);
        }
        else
            GetComponent<Rigidbody>().freezeRotation = false;
    }
    bool IsGrounded()
    {
        bool hit=Physics.Raycast(transform.position,-transform.up,1f,groundLayer);
        if (hit)
            return true;
        return false;
    }
}
