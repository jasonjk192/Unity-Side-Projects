using UnityEngine;
using System.Collections;

public class DestroyOnContactScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		Destroy (other.gameObject);
	}
}
