using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexagon : MonoBehaviour {

    public Rigidbody2D rb;
    float f;
    public float shrinkspeed = 3f;
    public float ro=0f;
	void Start ()
    {
        transform.Rotate(new Vector3(0f,0f,Random.Range(0f,360f)));
        
        
        transform.localScale = Vector3.one * 10f;        
	}

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkspeed * Time.deltaTime;

        if (transform.localScale.x < -0.05f)
        {
            Destroy(gameObject);
        }
	}
}
