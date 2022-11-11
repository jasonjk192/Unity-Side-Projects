using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatescript : MonoBehaviour {

    public static float speed = 200f;

    private float time;
    private float timeInterval = 5f;
    [SerializeField]
    private int coutdown = 1;
    void Update ()
    {
        time += Time.deltaTime;
        if(time>timeInterval)
        {
            time -= (timeInterval+4f);
            if (coutdown == 1)
            {


                speed = 50f;
                StartCoroutine(re());
            }     



        }
        if (pinscript.isPlaying)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
    IEnumerator re()
    {
        yield return new WaitForSeconds(4f);
        speed = 200f;
        coutdown = 1;
    }
   
}
