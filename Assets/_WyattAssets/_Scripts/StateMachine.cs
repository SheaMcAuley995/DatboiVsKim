using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum boiState
{
    wander,
    runAwau,
    Attack
}


public class StateMachine : MonoBehaviour
{
    FollowKimScript follow;
    WanderScript wander;
    GetMoreWarriors flock;
    testDuplicateOfGetMoreWarriors flock2;

    public new AudioSource audio;
    public AudioClip[] Chasingclips;
    public AudioClip[] Roamclips;
    public GameObject target;
    public GameObject knuckles;

    public float distance;
    public boiState state;

    void Start ()
    { 
        audio = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Kim");
        follow = GetComponent<FollowKimScript>();
        wander = GetComponent<WanderScript>();
        flock = GetComponent<GetMoreWarriors>();
        flock2 = GetComponent<testDuplicateOfGetMoreWarriors>();
	}
	

	void Update () 
    {
        float distancefrom = Vector3.Distance(knuckles.transform.position, target.transform.position);
        flock2.DoFlock();


        switch (state)
        {
            case boiState.wander:

                if (audio.isPlaying == false)
                {
                    audio.PlayOneShot(Roamclips[Random.Range(0, 4)]);   
                }
                if (target == null)
                {
                    audio.Stop();
                }
                wander.DoWander();
                break;
            case boiState.Attack:
                if (audio.isPlaying == false)
                {
                    audio.PlayOneShot(Chasingclips[Random.Range(0, 4)]);
                }
                if (target == null)
                {
                    audio.Stop();
                }
                follow.DoFollow();
                break;
            case boiState.runAwau:
                flock2.DoRun();
                break;    
        }




        if(state != boiState.runAwau)
        {
            if (distancefrom <= distance)
            {
                state = boiState.Attack;
            }
            else
            {
                state = boiState.wander;
            }
        }
	}
}
