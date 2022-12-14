using UnityEngine;
using System.Collections;

public class hatController : MonoBehaviour {

	public Camera cam;

	private float maxwidth;

	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float hatWidth = GetComponent<Renderer>().bounds.extents.x;
		maxwidth = targetWidth.x-hatWidth;
	}
	
	void FixedUpdate () {
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, -3f, 0f);
		float targetWidth = Mathf.Clamp (targetPosition.x, -maxwidth, maxwidth);
		targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
		GetComponent<Rigidbody2D>().MovePosition (targetPosition);
	}
}
