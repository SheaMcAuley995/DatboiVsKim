using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderScript : MonoBehaviour
{
    NavMeshAgent knuckles;

    public float speed;
    public float radius;
    public float jitter;
    public float distance;
    public Vector3 target;
    public Rigidbody rb;


    void Start()
    {
        knuckles = GetComponent<NavMeshAgent>();
    }


    public void DoWander()
    {

        knuckles.destination = (transform.position + returnWanderPoints());
    }


    public Vector3 returnWanderPoints()
    {
        target = Vector3.zero;
        target = Random.insideUnitCircle.normalized * radius;
        target = (Vector2)target + Random.insideUnitCircle * jitter;
        target.z = target.y;
        target.y = 0;
        target += transform.position;
        target += transform.forward * distance;
        Vector3 dir = (target - transform.position).normalized;
        Vector3 desiredVel = dir * speed;
        return target;
    }
}
