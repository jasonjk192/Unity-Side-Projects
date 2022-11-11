﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {



    public enum SwipeDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    public static event Action<SwipeDirection> Swipe;
    private bool swiping = false;
    private bool eventSent = false;
    private Vector2 lastPosition;

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0)
        {
            if (swiping == false)
            {
                swiping = true;
                lastPosition = Input.GetTouch(0).position;
                return;
            }
            else
            {
                if (!eventSent)
                {
                    if (Swipe != null)
                    {
                        Vector2 direction = Input.GetTouch(0).position - lastPosition;

                        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        {
                            if (direction.x > 0)
                                Swipe(SwipeDirection.Right);
                            else
                                Swipe(SwipeDirection.Left);
                        }
                        else
                        {
                            if (direction.y > 0)
                                Swipe(SwipeDirection.Up);
                            else
                                Swipe(SwipeDirection.Down);
                        }

                        eventSent = true;
                    }
                }
            }
        }
        else
        {
            swiping = false;
            eventSent = false;
        }
    }




    /*void Update ()
    {
        if (Input.touchCount > 0)
        {
            float x = Input.GetTouch(0).deltaPosition.x;
            float y = Input.GetTouch(0).deltaPosition.y;
            if(Mathf.Abs(x)>Mathf.Abs(y))
            {
                if (Input.GetTouch(0).deltaPosition.x < 0)
                {
                    this.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = Color.blue;
                }
            }
            else
            {
                if (Input.GetTouch(0).deltaPosition.y > 0)
                {
                    this.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
            }
        }
    }*/

}
