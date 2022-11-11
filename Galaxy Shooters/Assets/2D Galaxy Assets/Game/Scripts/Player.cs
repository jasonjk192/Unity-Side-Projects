using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	private bool canTripleShot = false;
	private bool canSpeed = false;
	private bool hasShield = false;

	private SpriteRenderer sp;

	[SerializeField]
	private GameObject[] _engines;
	[SerializeField]
	private GameObject _ShieldGameObject;
	[SerializeField]
	private GameObject _ExplosionPrefab;
	[SerializeField]
	private GameObject _laserPrefab;
	[SerializeField]
	private GameObject _tripleShotPrefab;
	[SerializeField]
	private float _fireRate=0.25f;
	[SerializeField]
	private int _lives=3;

	private float _nextFire = 0.0f;

	private UIManager _uimanager;
	private AudioSource _audioSource;
	private int randomEngineFail;

	[SerializeField]
	private float _speed;

	void Start () 
	{
		randomEngineFail = Random.Range (0, 2);
		
		_uimanager = GameObject.Find ("Canvas").GetComponent<UIManager> ();
		if(_uimanager!=null)
		{
			_uimanager.UpdateLives (_lives);
		}
        if(_uimanager.isCoop==false)
        {
            transform.position = new Vector3(0, 0, 0);
        }
		_audioSource = GetComponent<AudioSource> ();
	}
	
	void Update () 
	{
		Movement ();
		if (Input.GetKeyDown (KeyCode.Space)||Input.GetMouseButton(0)) 
		{
			Shoot ();
		}

	}
	private void Shoot()
	{
		if (Time.time > _nextFire) 
		{
			_audioSource.Play ();
			if (canTripleShot == true)
			{
				Instantiate (_tripleShotPrefab, transform.position+new Vector3(0,0,0), Quaternion.identity);
			} 
			else
			{
				Instantiate (_laserPrefab, transform.position + new Vector3 (0, 0.9f, 0), Quaternion.identity);
			}
			_nextFire = Time.time + _fireRate;
		}
	}
	private void Movement()
	{
		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");

		if (canSpeed) 
		{
			transform.Translate (Vector3.right * 1.5f * _speed * horizontalInput * Time.deltaTime);
			transform.Translate (Vector3.up * 1.5f * _speed * verticalInput * Time.deltaTime);
		} else 
		{
			transform.Translate (Vector3.right * _speed * horizontalInput * Time.deltaTime);
			transform.Translate (Vector3.up * _speed * verticalInput * Time.deltaTime);
		}

		if (transform.position.y > 0) 
		{
			transform.position = new Vector3 (transform.position.x, 0, 0);
		} 
		else if (transform.position.y < -4.2f) 
		{
			transform.position = new Vector3 (transform.position.x, -4.2f, 0);
		}

		if (transform.position.x > 9.2f) 
		{
			transform.position = new Vector3 (-9.2f, transform.position.y, 0);
		}
		else if (transform.position.x < -9.2f)
		{
			transform.position = new Vector3 (9.2f, transform.position.y, 0);
		}
	}

	public void DecreaseLives()
	{
		if (hasShield == true) 
		{
			hasShield = false;
			sp.color = Color.white;
			_ShieldGameObject.SetActive (false);
			return;
		}
		else 
		{
			--_lives;
			_uimanager.UpdateLives (_lives);
			_engines [randomEngineFail].SetActive (true);
			if (randomEngineFail == 0)
				randomEngineFail = 1;
			else
				randomEngineFail = 0;
		}
		if (_lives < 1)
		{
			Destroy (gameObject);
			Instantiate (_ExplosionPrefab, transform.position, Quaternion.identity);
			_uimanager.activateTitle ();
		}
	}
	public void TripleShotPowerupOn()
	{
		canTripleShot = true;
		StartCoroutine (TripleShotPowerDownRoutine ());
	}
	IEnumerator TripleShotPowerDownRoutine()
	{
		yield return new WaitForSeconds (5f);
		canTripleShot = false;
	}

	public void SpeedPowerupOn()
	{
		canSpeed = true;
		StartCoroutine (SpeedPowerDownRoutine ());
	}
	IEnumerator SpeedPowerDownRoutine()
	{
		yield return new WaitForSeconds (5f);
		canSpeed = false;
	}
	public void ShieldPowerupOn()
	{
		hasShield = true;
		sp = GetComponent<SpriteRenderer> ();
		sp.color = Color.cyan;
		_ShieldGameObject.SetActive (true);
		StartCoroutine (ShieldPowerDownRoutine ());
	}
	IEnumerator ShieldPowerDownRoutine()
	{
		yield return new WaitForSeconds (10f);
		hasShield = false;
		sp.color = Color.white;
		_ShieldGameObject.SetActive (false);
	}
}
