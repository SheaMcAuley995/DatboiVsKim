using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheWay : MonoBehaviour {


    public float SearchRadius;
    
    Transform closest;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ExplosionDamage(transform.position, SearchRadius);
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, SearchRadius);
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        float closestDist = 9999;
        foreach (Collider guyhit in hitColliders)
        {
            if (guyhit.tag == "Knuckles")
            {
                if (Vector3.Distance(transform.position, guyhit.transform.position) < closestDist)
                {
                    closest = guyhit.transform;
                    closestDist = Vector3.Distance(transform.position, closest.transform.position);
                    
                }
                Debug.DrawLine(transform.position, closest.transform.position);
            }
        }
    }
}
