using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Sprite[] lives;
	public Image livesImageDisplay;
	public Text scoreText;
	public int score;
    public bool isCoop = false;

	[SerializeField]
	private GameObject _player;
	[SerializeField]
	private GameObject _spawnManager;
	[SerializeField]
	private GameObject _title;

	private GameObject _sm;

	void Start()
	{
		scoreText.text = "Score : " + score;
		UpdateLives (0);
		if (_title.activeInHierarchy == false)
			_title.SetActive (true);
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.Space)&&_title.activeInHierarchy) 
		{
			Instantiate (_player,Vector3.zero, Quaternion.identity);
			_sm=Instantiate (_spawnManager,new Vector3(0,9,0), Quaternion.identity);
			score = 0;
			scoreText.text = "Score : " + score;
			_title.SetActive (false);
		}
	}
	public void UpdateLives(int currentLives)
	{
		livesImageDisplay.sprite = lives [currentLives];
	}
	public void UpdateScore()
	{
		score += 10;
		scoreText.text = "Score : " + score;
	}
	public void activateTitle()
	{
		Destroy (_sm);
		_title.SetActive (true);
	}
}
