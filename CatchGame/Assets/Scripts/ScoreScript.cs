using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public Text scoreText;
	public int ballValue;

	private int score;

	void Start () {
		score = 0;
		UpdateScore ();
	}

	void OnTriggerEnter2D()
	{
		score += ballValue;
		UpdateScore ();
	}
	void UpdateScore()
	{
		scoreText.text = "Score  :\n" + score;
	}
}
