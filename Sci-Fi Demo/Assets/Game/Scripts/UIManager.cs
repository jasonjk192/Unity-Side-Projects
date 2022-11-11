using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private Image _coinImage;
    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo : " + count;
    }
    public void UpdateCoin(bool setCoin)
    {
        _coinImage.gameObject.SetActive(setCoin);
    }
}
