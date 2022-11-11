using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

	public Camera cam;
	public GameObject ball;
	public float timeLeft;
	public Text timerText;
	public GameObject gameovertext;
	public GameObject restartbutton;

	private float maxwidth;

	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
		maxwidth = targetWidth.x-ballWidth;
		StartCoroutine (Spawn());
		UpdateText ();
	}

	void FixedUpdate()
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
			timeLeft = 0;
		UpdateText ();
	}

	IEnumerator Spawn ()
	{
		yield return new WaitForSeconds (2.0f);
		while (timeLeft>0.0f) {
			Vector3 spawnPosition = new Vector3 (
				Random.Range (-maxwidth, maxwidth),
				transform.position.y,
				transform.position.z
				);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range(1.0f,2.0f));
		}
		yield return new WaitForSeconds (1.5f);
		gameovertext.SetActive (true);
		yield return new WaitForSeconds (1.5f);
		restartbutton.SetActive (true);
	}
	void UpdateText()
	{
		timerText.text = "Time left :\n"+Mathf.RoundToInt(timeLeft);
	}
}
