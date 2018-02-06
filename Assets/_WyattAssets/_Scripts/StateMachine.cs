using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    FollowKimScript follow;
    WanderScript wander;

    public GameObject target;
    public GameObject knuckles;

    public float distance;

    public bool uh;

    void Start ()
    {
        
        follow = GetComponent<FollowKimScript>();
        wander = GetComponent<WanderScript>();
	}
	

	void Update () 
    {
        float distancefrom = Vector3.Distance(knuckles.transform.position, target.transform.position);
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
            follow.DoFollow();
        }
        else
        {
            wander.DoWander();
        }

        Debug.Log(distancefrom);
	}
}
