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
        target = GameObject.FindGameObjectWithTag("Kim");
        knuckles = GetComponent<NavMeshAgent>();
	}


    public void DoFollow ()
    {
        MoveTowardsPoint();
        float distancefrom = Vector3.Distance(transform.position, target.transform.position);

        if (distancefrom <= distance)
        {
            knuckles.destination = MoveTowardsPoint();
        }
    }


    public Vector3 MoveTowardsPoint()
    {
        return target.transform.position;
    }
}
