using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 4f;
    [SerializeField]
    float rotSpeed = 4f;
    [SerializeField]
    float vel = 0f;

    Vector3 forward, right;

	void Start () {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}
	
	void Update () {
        vel = Vector3.Magnitude(GetComponent<Rigidbody>().velocity);
    }
    void FixedUpdate()
    {
        if (Input.anyKey)
            Move();
    }
        void Move()
    {
        Vector3 rightMovement = right * Input.GetAxis("HKey");
        Vector3 upMovement = forward * Input.GetAxis("VKey");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(heading), rotSpeed * Time.deltaTime);
        GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        if (Vector3.Magnitude(GetComponent<Rigidbody>().velocity) > moveSpeed)
            GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, moveSpeed);
    }
}
