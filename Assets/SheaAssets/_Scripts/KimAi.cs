using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public enum KimState
{
    wander,
    runAway,
    Attack
}


public class KimAi : MonoBehaviour {


    [HideInInspector]
    public Stack<KimWander> behaviors;
    [HideInInspector]
    public NavMeshAgent agent;

    Shoot shoot;
    FindTheWay findTheWay;
    KimWander kimWander;


    public float SearchRadius;



    KimState state;
    //public GameObject walkTarget;
    //WalkTowardsBehaviour walkTowards;
    // Use this for initialization
    void Start()
    {
        shoot = GetComponent<Shoot>();
        kimWander = GetComponent<KimWander>();
        findTheWay = GetComponent<FindTheWay>();
        agent = GetComponent<NavMeshAgent>();
        behaviors = new Stack<KimWander>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case KimState.Attack:
                float step = findTheWay.speed * Time.deltaTime;
                Transform closest = findTheWay.findTarget(transform.position, SearchRadius);

                if (closest != null)
                { findTheWay.targetDir = findTheWay.closest.transform.position - transform.position; }

                Vector3 newDir = Vector3.RotateTowards(transform.forward, findTheWay.targetDir, step, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);
                shoot.Shooting();

                break;


            case KimState.wander:

                agent.destination = (kimWander.returnWanderPoints());
                break;

        }

        


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, SearchRadius);
    }
}