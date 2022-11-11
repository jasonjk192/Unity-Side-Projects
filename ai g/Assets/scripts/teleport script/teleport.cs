using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

    [SerializeField]
    private Vector3 teleportpos;
    [SerializeField]
    private bool getArrow;

    private GameObject[] pathArrow;
    private GameObject[] wrongwayArrow;
    private GameObject Info;
	void Awake ()
    {
        if(getArrow)
        {
            pathArrow = GameObject.FindGameObjectsWithTag("PathArrow");
            wrongwayArrow = GameObject.FindGameObjectsWithTag("WrongPathArrow");
            Info = GameObject.FindGameObjectWithTag("info");
            foreach (GameObject obj in wrongwayArrow)
            {
                obj.SetActive(false);
            }
                


        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider target)
    {
        if(target.tag =="ball")
        {
            target.transform.position = teleportpos;
        }
        if(getArrow)
        {
            foreach(GameObject obj in pathArrow)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in wrongwayArrow)
            {
                obj.SetActive(true);
            }
            Info.SetActive(false);
        }
    }
}
