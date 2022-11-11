using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ballsound : MonoBehaviour {
    public Rigidbody mybody;
    private ballmovement ballmovement;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip pickUp,Wallhit;
    [SerializeField]
    private AudioSource BallRollAudio;
    private Vector3 velocitylastframe;
    private Vector3 collisionnormal;
    private float xAxisAngle, xfactor;
    private float yAxisAngle, yfactor;
    private float zAxisAngle, zfactor;
    
    void Awake ()
    {
        mybody = GetComponent<Rigidbody>();
        ballmovement = GetComponent<ballmovement>();
	}
    void Update ()
    {
        BallRollSoundController();	
	}
    private void LateUpdate()
    {
        velocitylastframe = mybody.velocity;
    }
    void BallRollSoundController()
    {
        if (ballmovement.onfloorTracker >0 && mybody.velocity.sqrMagnitude > 0)
        {
            BallRollAudio.volume = mybody.velocity.sqrMagnitude * 0.0002f;
            BallRollAudio.pitch = 0.4f + BallRollAudio.volume;
            BallRollAudio.mute = false;
        }
        else
        {
            BallRollAudio.mute = true;
        }
    }
    public void PlayPickUpSound()
    {
        audioSource.volume = 0.7f;
        audioSource.PlayOneShot(pickUp);
    }
    void SetSoundVolumeOnCollision(Collision collision)
    {
        collisionnormal = collision.contacts[0].normal;
        xAxisAngle = Vector3.Angle(Vector3.right, collisionnormal);//returns the angle in degree between from and to
        xfactor = (1f / 8100f) * xAxisAngle * xAxisAngle + (-1 / 45f) + 1f;

        yAxisAngle = Vector3.Angle(Vector3.up, collisionnormal);
        yfactor = (1f / 8100f) * yAxisAngle * yAxisAngle + (-1 / 45f) + 1f;

        zAxisAngle = Vector3.Angle(Vector3.forward, collisionnormal);
        zfactor = (1f / 8100f) * zAxisAngle * zAxisAngle + (-1 / 45f) + 1f;

        audioSource.volume = (Mathf.Abs(velocitylastframe.x * xfactor * 0.001f)) +
            (Mathf.Abs(velocitylastframe.y * yfactor * 0.001f)) + 
            (Mathf.Abs(velocitylastframe.z * zfactor * 0.001f));
    }
    void OnCollisionEnter(Collision target)
    {
        SetSoundVolumeOnCollision(target);
        if(target.gameObject.tag=="wall")
        {
            audioSource.PlayOneShot(Wallhit);
        }
    }
}
