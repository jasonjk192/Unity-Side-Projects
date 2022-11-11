using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour {

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "level")
        {
            SceneManager.LoadScene(target.gameObject.name);
        }
    }

}
