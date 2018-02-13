using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDuplicateOfGetMoreWarriors : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent nav;

    Vector3 Cforce;
    Vector3 Aforce;
    Vector3 Sforce;
    public GameObject kim;
    public float speed;
    [Tooltip ("radius for flock")]
    public float radius;
    [Tooltip("radius for kim detection")]
    public float radius2;
    bool flocking;
    bool Run;
    [Tooltip ("is kim in the hood?")]
    public bool isKim;
    StateMachine state;
    public int showHoodsize;
    void Start()
    {
        Run = false;
        state = GetComponent<StateMachine>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void DoFlock()
    {
        flocking = true;
        kim = null;
        Vector3 Ctarget = Vector3.zero;
        Vector3 aDesire = Vector3.zero;
        Vector3 sSum = Vector3.zero;
        //~~~hood for regular flocking

        int hoodSize = 0;
        Collider[] hood = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider guyInHood in hood)
        {
            var Flocker = guyInHood.GetComponent<GetMoreWarriors>();
            if (Flocker != null)
            {
                hoodSize++;
                UnityEngine.AI.NavMeshAgent otherNav = guyInHood.GetComponent<UnityEngine.AI.NavMeshAgent>();

                Ctarget += Flocker.transform.position;
                aDesire += otherNav.velocity;
                sSum += (transform.position - guyInHood.transform.position) / radius;
            }
        }
        if (flocking)
        {
            Ctarget /= hoodSize;
            aDesire /= hoodSize;
            sSum /= hoodSize;

            Cforce = (Ctarget - transform.position).normalized * speed - nav.velocity;
            Aforce = aDesire.normalized * speed - nav.velocity;
            Sforce = sSum.normalized * speed - nav.velocity;

            nav.destination = ((Cforce + Aforce + Sforce).normalized * speed) + transform.position;
        }




        isKim = false;
        //~~~~ hood for detecting kim with a larger radius than the hood used for flocking
        int hoodSize2 = 0;
        Collider[] hood2 = Physics.OverlapSphere(transform.position, radius2);

        foreach (Collider guyInHood2 in hood2)
        {
            Run = false;
            var Flocker2 = guyInHood2.GetComponent<testDuplicateOfGetMoreWarriors>();
            if (Flocker2 != null)
            {
                hoodSize2++;
                showHoodsize = hoodSize2;
                UnityEngine.AI.NavMeshAgent otherNav = guyInHood2.GetComponent<UnityEngine.AI.NavMeshAgent>();
            }
            if (guyInHood2.tag == "Kim")
            {
                kim = guyInHood2.gameObject;
                isKim = true;
            }
            
        }
        if (hoodSize2 <= 2 && kim != null)
        {
            Run = true;
        }

        if (hoodSize2 >= 3 && kim != null)
        {
            state.state = boiState.wander;
        }
        if(Run != true)
        {
            nav.speed = 10;
        }

        if (Run)
        {
            state.state = boiState.runAwau;
        }
    }
    public void DoRun()
    {
        if(kim != null)
        {
            nav.destination = RunFromPoint();
            nav.speed = 50;
        }
        if(kim == null)
        {
            state.state = boiState.wander;
        }
    }

    public Vector3 RunFromPoint()
    {
        return -kim.transform.position; 
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.black;
        //Gizmos.DrawWireSphere(transform.position, radius);
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, radius2);
    }
}
