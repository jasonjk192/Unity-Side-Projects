using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinspawner : MonoBehaviour {

    [SerializeField]
    private GameObject pinPrefab;
    
    public int c =0;
    void Update()
    {
        if (pinscript.isPlaying)
        {
            if (Input.GetMouseButtonDown(1))
            {
                c++;
                if (c == 4)
                {
                    c = 0;
                    rotatescript.speed *= -1;
                }
                    spawnpin();
                

            }
        }
    }
    void spawnpin()
    {
        Instantiate(pinPrefab, transform.position, transform.rotation);
        
    }
}
