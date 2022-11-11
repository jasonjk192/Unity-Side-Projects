using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	[SerializeField]
	private float _speed = 10f;
	[SerializeField]
	private AudioClip _clip;

	private UIManager _uimanager;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * _speed * Time.deltaTime);
		if (transform.position.y > 5.5f) {
			Destroy (gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			_uimanager = GameObject.Find ("Canvas").GetComponent<UIManager> ();
			if(_uimanager!=null)
			{
				_uimanager.UpdateScore ();
			}
			AudioSource.PlayClipAtPoint (_clip,other.transform.position);
			Destroy (other.gameObject);
			Instantiate (other.GetComponent<EnemyAI>().enemyExplosion,other.gameObject.transform.position,Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
