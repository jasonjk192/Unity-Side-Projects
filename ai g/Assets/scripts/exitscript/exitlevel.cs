using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitlevel : MonoBehaviour {

	void OnTriggerEnter(Collider target)
    {
        if(target.tag=="ball")
        {
            Debug.Log("here");
            StartCoroutine(LoadMainMenu());
        }
    }
    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("main");
    }
}
