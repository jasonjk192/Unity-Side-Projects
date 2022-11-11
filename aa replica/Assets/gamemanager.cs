using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour {

    public Animator anim;

	void Update ()
    {
    if(!pinscript.isPlaying)
        {
            anim.SetTrigger("EndGame");
            StartCoroutine(restart());
        }
        
	}
    IEnumerator restart()
    {
        yield return new WaitForSeconds(.5f);
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            pinscript.isPlaying = true;
            rotatescript.speed = 200f;
        }
    }
}
