using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool pointerdown;
    public UnityEvent OnHoldClick;



    void Update()
    {
        if (pointerdown)
        {
            if (OnHoldClick != null)
            {
                OnHoldClick.Invoke();
            }
        }

    }
    private void Reset()
    {
        pointerdown = false;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("ButtonUp");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        pointerdown = true;
        Debug.Log("ButtonDown");
    }
}
