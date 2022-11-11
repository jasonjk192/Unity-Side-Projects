using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	public GameObject enemyExplosion;
	[SerializeField]
	private AudioClip _clip;

	// Use this for initialization
	void Start () {
		transform.position=new Vector3(Random.Range (-7.7f, 7.7f),6.3f,0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * speed * Time.deltaTime);
		if (transform.position.y < -6.3f) 
		{
			transform.position=new Vector3(Random.Range (-7.7f, 7.7f),6.3f,0);
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			AudioSource.PlayClipAtPoint (_clip,transform.position);
			Destroy (gameObject);
			Instantiate (enemyExplosion,this.gameObject.transform.position,Quaternion.identity);
			other.GetComponent<Player> ().DecreaseLives ();

		}
	}
}
