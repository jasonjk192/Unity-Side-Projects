using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyballtrigger : MonoBehaviour {

    private Rigidbody mybody;
    [SerializeField]
    private AudioSource BallRollAudio, audioSource, stunned;

    [SerializeField]
    private AudioClip WallHit, stunnedclip;

    private Vector3 velocitylastframe;
    private Vector3 collisionnormal;
    private float xAxisAngle, xfactor;
    private float yAxisAngle, yfactor;
    private float zAxisAngle, zfactor;
    private enemyball enemy;
    private MeshRenderer myrenderer;
   
    void Awake ()
    {
        mybody = GetComponent<Rigidbody>();
        enemy = GetComponent<enemyball>();
        myrenderer = GetComponent<MeshRenderer>();
        
	}
	
    void Update () {
		
	}
    void LateUpdate()
    {
        velocitylastframe = mybody.velocity;
    }
    void BallRollSoundController()
    {
        if ( mybody.velocity.sqrMagnitude > 0)
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
    IEnumerator BallStunned()
    {
        yield return new WaitForSeconds(2f);
        enemy.stunned = false;
        myrenderer.material.color = new Color(16, 21, 41);
    }
    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "wall")
        {
            SetSoundVolumeOnCollision(target);
            if (!enemy.stunned && (Mathf.Abs(velocitylastframe.x) * xfactor +
                Mathf.Abs(velocitylastframe.y) * yfactor +
                Mathf.Abs(velocitylastframe.z) * zfactor) > 5f)
            {
                enemy.stunned = true;
                myrenderer.material.color = Color.yellow;
                stunned.PlayOneShot(stunnedclip);
                StartCoroutine(BallStunned());
            }
        }
        if (target.gameObject.tag == "ball")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }

    void OnTriggerEnter(Collider target)
    {
        if(target.tag=="ball")
        {
            gameObject.SendMessage("getballTarget", target.transform);
            gameObject.SendMessage("canAttackToggle", true);
        }

    }
    void OnTriggerExit(Collider target)
    {
        if(target.tag=="ball")
        {
            gameObject.SendMessage("canAttackToggle", false);
        }
    }
}
