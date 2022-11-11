using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereEnemyController : MonoBehaviour {

    [SerializeField]
    GameObject player;
    [SerializeField]
    float moveSpeed = 4f;
    [SerializeField]
    float vel;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -40)
            Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
        direction.y = 0;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 1 * Time.deltaTime);
        vel = Vector3.Magnitude(GetComponent<Rigidbody>().velocity);
        GetComponent<Rigidbody>().AddForce(direction * moveSpeed);
        if (Vector3.Magnitude(GetComponent<Rigidbody>().velocity) > moveSpeed)
            GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, moveSpeed);
    }
}
