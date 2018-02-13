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

    public float speed;
    public float radius;
    void Start ()
    {
        nav = GetComponent<NavMeshAgent>();
	}
	
	public void DoFlock ()
    {
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
                NavMeshAgent otherNav = guyInHood.GetComponent<NavMeshAgent>();

                Ctarget += Flocker.transform.position;
                aDesire += otherNav.velocity;
                sSum += (transform.position - guyInHood.transform.position) / radius;
            }
        }
        
        Ctarget /= hoodSize;
        aDesire /= hoodSize;
        sSum /= hoodSize;

        Cforce = (Ctarget - transform.position).normalized * speed - nav.velocity;
        Aforce = aDesire.normalized * speed - nav.velocity;
        Sforce = sSum.normalized * speed - nav.velocity;

        nav.destination = ((Cforce + Aforce + Sforce).normalized * speed) + transform.position;
    }
}
