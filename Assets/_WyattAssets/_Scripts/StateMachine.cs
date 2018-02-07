using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    FollowKimScript follow;
    WanderScript wander;


    public new AudioSource audio;
    public AudioClip[] Chasingclips;
    public AudioClip[] Roamclips;
    public GameObject target;
    public GameObject knuckles;

    public float distance;

    public bool uh;

    void Start ()
    { 
        audio = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Kim");
        follow = GetComponent<FollowKimScript>();
        wander = GetComponent<WanderScript>();
	}
	

	void Update () 
    {
        //float delayTime = Random.Range(44100, 88200);
        float distancefrom = Vector3.Distance(knuckles.transform.position, target.transform.position);
        Debug.Log(distancefrom);
        Debug.Log("this is the targets position" + target.transform.position);
        if (distancefrom <= distance)
        {
            uh = true;
        }
        else
        {
            uh = false;

        }

        if (uh)
        {

            if (audio.isPlaying == false)
            {
                audio.PlayOneShot(Chasingclips[Random.Range(0,5)]);
            }
            follow.DoFollow();
        }
        else
        {
            if (audio.isPlaying == false)
            {
                audio.PlayOneShot(Roamclips[Random.Range(0, 4)]);
            }
            wander.DoWander();   
        }
	}
}
