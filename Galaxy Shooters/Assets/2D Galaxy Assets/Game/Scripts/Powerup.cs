using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	[SerializeField]
	private float _speed = 3f;
	[SerializeField]
	private float _powerupID;
	[SerializeField]
	private AudioClip _clip;

	void Update () {
		transform.Translate (Vector3.down * _speed * Time.deltaTime);
		if (transform.position.y < -7) 
		{
			Destroy (gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Player p = other.GetComponent<Player> ();
			if (p != null) 
			{
				if (_powerupID == 0) 
				{
					p.TripleShotPowerupOn ();
				} 
				else if (_powerupID == 1) 
				{
					p.SpeedPowerupOn ();
				} 
				else if (_powerupID == 2) 
				{
					p.ShieldPowerupOn ();
				}
			}
			AudioSource.PlayClipAtPoint(_clip,Camera.main.transform.position,1f);
			Destroy (this.gameObject);
		}
	}
}
