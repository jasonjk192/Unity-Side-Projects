using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switcher : MonoBehaviour {

    [SerializeField]
    private  GameObject redwall;
    [SerializeField]
    public  GameObject bluewall;
    private bool redwallturnedoff;
    private bool bluewallturnedoff;
    private Renderer myrenderer;
    private void Awake()
    {
        myrenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "ball" && gameObject.tag == "red" && redwallturnedoff == false)
        {
            redwall.SetActive(false);
            redwallturnedoff = true;
            myrenderer.material.color = Color.black;
        }
        else if (target.gameObject.tag == "ball" && gameObject.tag == "red" && redwallturnedoff == true)
        {
            redwall.SetActive(true);
            redwallturnedoff = false;
            myrenderer.material.color = Color.red;
        }
        else if (target.gameObject.tag == "ball" && gameObject.tag == "blue" && bluewallturnedoff == false)
        {
            bluewall.SetActive(false);
            bluewallturnedoff = true;
            myrenderer.material.color = Color.black;
        }
        else if (target.gameObject.tag == "ball" && gameObject.tag == "blue" && bluewallturnedoff == true)
        {
            bluewall.SetActive(true);
            bluewallturnedoff = false;
            myrenderer.material.color = Color.blue;
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
