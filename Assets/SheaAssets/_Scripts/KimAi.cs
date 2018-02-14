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

    Transform closest = null;
    public Vector3 targetDir;
    public float speed;
    

    Shoot shoot;
    //FindTheWay findTheWay;
    KimWander kimWander;


    public float SearchRadius;
    public float knowlegeSphere;
    private int howManyNucks;
   

    KimState state;
    //public GameObject walkTarget;
    //WalkTowardsBehaviour walkTowards;
    // Use this for initialization
    void Start()
    {
        shoot = GetComponent<Shoot>();
        kimWander = GetComponent<KimWander>();
      //  findTheWay = GetComponent<FindTheWay>();
        agent = GetComponent<NavMeshAgent>();
        behaviors = new Stack<KimWander>();

    }

    // Update is called once per frame
    void Update()
    {
        


        //state = KimState.Attack;
        switch (state)
        {
            
            case KimState.Attack:
                float step = speed * Time.deltaTime;
                //Transform closest = findTarget(transform.position, SearchRadius);

                if (closest != null)
                { targetDir = closest.transform.position - transform.position; }
                
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                transform.position -= (transform.forward * Time.deltaTime) * 3;
                transform.rotation = Quaternion.LookRotation(newDir);
                shoot.Shooting();

                break;


            case KimState.wander:
                //Debug.Log("Wandering");
                agent.destination = (kimWander.returnWanderPoints());
                break;

        }


        findKnuckles(transform.position, SearchRadius);


        if (closest != null)
        {
            state = KimState.Attack;
            
        }
        else
        {
            state = KimState.wander;
        }

    }

    //void attainKnowlege(Vector3 center, float radius)
    //{
    //    Collider[] nearMe = Physics.OverlapSphere(center, radius);

    //    if
    //}
    private void doRun()
    {
        agent.destination = RunFromPoint();
        agent.speed = 50;
    }
    public Vector3 RunFromPoint()
    {
        return -closest.transform.position;
    }
    void findKnuckles(Vector3 center, float radius)
    {
    Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        closest = null;
    float closestDist = 9999;
        
        foreach (Collider guyhit in hitColliders)
        {
           
            if (guyhit.tag == "Knuckles")
            {
                state = KimState.Attack;
                if (Vector3.Distance(transform.position, guyhit.transform.position) < closestDist)
                {
                    closest = guyhit.transform;
                    closestDist = Vector3.Distance(transform.position, closest.transform.position);
                    
                }
                if(hitColliders.Length >= 10)
                {
                    
                }
            }
           
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, SearchRadius);
    }
}