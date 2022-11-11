using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {
    [SerializeField]
    private GameObject _sharkCollision;
    [SerializeField]
    private AudioClip _coinPickUp;
    UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (other.GetComponent<Player>().getCoin() > 0)
                {
                    other.GetComponent<Player>().giveCoin(-1);
                    _uiManager.UpdateCoin(false);
                    AudioSource.PlayClipAtPoint(_coinPickUp, transform.position, 1f);
                    other.GetComponent<Player>().enableWeapon(true);
                }
                else
                    Debug.Log("Get out!");
            }
        }
    }
}
