using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowKimScript : MonoBehaviour
{
    NavMeshAgent knuckles;

    public float speed;
    public float distance;
    public GameObject target;
    public Rigidbody rb;


    void Start ()
    {
        knuckles = GetComponent<NavMeshAgent>();
	}


    public void DoFollow ()
    {
        float distancefrom = Vector3.Distance(transform.position, target.transform.position);
         if(distancefrom <= distance)
        knuckles.destination = (MoveTowardsPoint());
    }


    public Vector3 MoveTowardsPoint()
    {
        return target.transform.position;
    }
        
}
