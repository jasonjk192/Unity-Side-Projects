using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinspawner_down: MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D mybody;
    private bool isPinned = false;
    [HideInInspector]
    public static bool isPlaying = true;

    void Update()
    {
        if (!isPinned)
        {
            mybody.MovePosition(mybody.position + Vector2.up * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rotator")
        {
            transform.SetParent(other.transform);
            isPinned = true;
        }
        if (other.tag == "pin")
        {
            isPlaying = false;
        }
    }
}
