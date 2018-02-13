using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GetMoreWarriors : MonoBehaviour
{
    NavMeshAgent nav;

    Vector3 Cforce;
    Vector3 Aforce;
    Vector3 Sforce;
    public GameObject kim;
    public float speed;
    public float radius;
    bool flocking;
    bool Run;
    StateMachine state;
    public int showHoodsize;
    void Start ()
    {
        Run = false;
        state = GetComponent<StateMachine>();
        nav = GetComponent<NavMeshAgent>();
	}
	
	public void DoFlock ()
    {
        flocking = true;
        kim = null;
        Vector3 Ctarget = Vector3.zero;
        Vector3 aDesire = Vector3.zero;
        Vector3 sSum = Vector3.zero;


        int hoodSize = 0;
        Collider[] hood = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider guyInHood in hood)
        {
            var Flocker = guyInHood.GetComponent<GetMoreWarriors>();
            if (Flocker != null)
            {
                hoodSize++;
                showHoodsize = hoodSize;
                NavMeshAgent otherNav = guyInHood.GetComponent<NavMeshAgent>();

                Ctarget += Flocker.transform.position;
                aDesire += otherNav.velocity;
                sSum += (transform.position - guyInHood.transform.position) / radius;
            }
            if(guyInHood.tag == "Kim")
            {
                kim = guyInHood.gameObject;
            }
            if(guyInHood.tag != "Kim")
            {
                Run = false;
                nav.speed = 10;
            }
        }
        if (hoodSize <= 2 && kim != null)
        {
            Run = true;
        }

        if (hoodSize >= 3 && kim != null)
        {
            state.state = boiState.wander;
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
        if(Run)
        {
            state.state = boiState.runAwau;
        }
       
    }
    public void DoRun()
    {
        nav.destination = RunFromPoint();
        nav.speed = 50;
    }

    public Vector3 RunFromPoint()
    {
        return -kim.transform.position;
    }
    private void OnDrawGizmos()
    {
    //    Gizmos.color = Color.black;
      //  Gizmos.DrawWireSphere(transform.position, radius);
    }
}
