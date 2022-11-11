using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    [SerializeField]
    private AudioClip _coinPickUp;
    UIManager _uiManager;
    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<Player>().giveCoin(1);
                AudioSource.PlayClipAtPoint(_coinPickUp,transform.position,1f);
                _uiManager.UpdateCoin(true);
                Destroy(this.gameObject,0.1f);
            }
        }
    }
}
