using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class KimWander : MonoBehaviour
{

    NavMeshAgent knuckles;

    public float speed;
    public float radius;
    public float jitter;
    public float distance;
    public Vector3 target;
    public Rigidbody rb;
    public bool allowWander;

    void Start()
    {
        knuckles = GetComponent<NavMeshAgent>();
    }
    public void Update()
    {
        if (allowWander)
        {
            knuckles.destination = (transform.position + returnWanderPoints());
        }
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
