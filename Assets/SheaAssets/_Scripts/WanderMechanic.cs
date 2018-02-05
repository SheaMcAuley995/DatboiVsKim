using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderMechanic : MonoBehaviour {

    public float speed;
    public float radius;
    public float jitter;
    public float distance;
    public Vector3 target;
    NavMeshAgent nav;
    public Rigidbody rb;
    public void Start()
    {

        nav = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        nav.destination = returnWanderPoints();
    }

    public Vector3 returnWanderPoints()
    {
        target = Vector3.zero;
        target = Random.insideUnitCircle.normalized * radius;
        target = (Vector2)target + Random.insideUnitCircle * jitter;
        target.z = target.y;
        target += transform.position;
        target += transform.forward * distance;
        target.y = transform.position.y;
        //Vector3 dir = (target - transform.position).normalized;
        //Vector3 desiredVelocity = dir * speed;
        return target;
    }
}
