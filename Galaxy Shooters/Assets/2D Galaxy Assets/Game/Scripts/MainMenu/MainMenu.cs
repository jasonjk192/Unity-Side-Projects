using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void LoadSinglePlayerGame()
    {
        SceneManager.LoadScene("Single_Player");
    }
    public void LoadCoopGame()
    {
        SceneManager.LoadScene("Co-op_Mode");
    }
}
