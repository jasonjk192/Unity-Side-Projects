using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    Color Red = new Color(236 / 255f, 116 / 255f, 116 / 255f);
    Color Green = new Color(116 / 255f, 236 / 255f, 152 / 255f);
    Color Blue = new Color(116 / 255f, 147 / 255f, 236 / 255f);
    Color Yellow = new Color(220 / 255f, 236 / 255f, 116 / 255f);

    [SerializeField]
    int waitTime;
    [SerializeField]
    private GameObject bg;
    bool waiting = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!waiting)
        {
            waiting = true;
            StartCoroutine("waitForChange");
        }
        
	}
    IEnumerator waitForChange()
    {
        yield return new WaitForSeconds(waitTime);
        int c = Random.Range(0, 4);
        Debug.Log("Color : " + c);
        switch (c)
        {
            case 0:
                bg.GetComponent<SpriteRenderer>().color = Red;
                break;
            case 1:
                bg.GetComponent<SpriteRenderer>().color = Blue;
                break;
            case 2:
                bg.GetComponent<SpriteRenderer>().color = Green;
                break;
            case 3:
                bg.GetComponent<SpriteRenderer>().color = Yellow;
                break;
        }
        waiting = false;
    }
}
