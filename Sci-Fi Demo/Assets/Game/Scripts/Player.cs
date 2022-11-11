using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _controller;
    [SerializeField]
    private GameObject muzzle;
    [SerializeField]
    private AudioSource _weaponAudio;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private int currentAmmo;
    [SerializeField]
    private int coins=0;
    private UIManager _uiManager;
    private float _gravity = 9.81f;
    private bool _isReloading = false;
    
    private int maxAmmo = 50;
	void Start () {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        currentAmmo = maxAmmo;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0) && currentAmmo > 0)
        {
            Shoot();
        }
        else
        {
            muzzle.SetActive(false);
            _weaponAudio.Stop();
        }
        if(Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
        }
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
        CalculateMovement();
	}

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        _isReloading = false;
        currentAmmo = maxAmmo;
        _uiManager.UpdateAmmo(currentAmmo);
    }
    void Shoot()
    {
        currentAmmo--;
        _uiManager.UpdateAmmo(currentAmmo);
        muzzle.SetActive(true);
        if (_weaponAudio.isPlaying == false)
            _weaponAudio.Play();
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Hit: " + hitInfo.transform.name);
            Object hitMark = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMark, 1f);
            Destructable crate = hitInfo.transform.GetComponent<Destructable>();
            if(crate!=null)
            {
                crate.DestroyCrate();
            }
        }
    }
    void CalculateMovement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(HorizontalInput, 0, VerticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
    public void giveCoin(int n)
    {
        coins += n;
    }
    public int getCoin()
    {
        return coins;
    }
    public void enableWeapon(bool enable)
    {
        _weapon.SetActive(enable);
    }
}
