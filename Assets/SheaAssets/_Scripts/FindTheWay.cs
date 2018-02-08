//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FindTheWay : MonoBehaviour {


//    public float SearchRadius;
//    public GameObject bullet;
//    Transform closest = null;

   

//	void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update () {
//        ExplosionDamage(transform.position, SearchRadius);
//        Debug.DrawLine(transform.position, closest.transform.position);
//    }

//    private void OnDrawGizmos()
//    {
//        Gizmos.color = Color.blue;
//        Gizmos.DrawWireSphere(transform.position, SearchRadius);
//    }



//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheWay : MonoBehaviour
{


    public float SearchRadius;
    public Rigidbody bullet;
    Transform closest = null;
  


    Vector3 targetDir;

    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        ExplosionDamage(transform.position, SearchRadius);
        targetDir = closest.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        newDir.y = 0;
        transform.rotation = Quaternion.LookRotation(newDir);
        Debug.DrawLine(transform.position, closest.transform.position);
        shootKnuckles();
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
        closest = null;
        foreach (Collider guyhit in hitColliders)
        {
            if (guyhit.tag == "Knuckles")
            {
                if (Vector3.Distance(transform.position, guyhit.transform.position) < closestDist)
                {
                    closest = guyhit.transform;
                    closestDist = Vector3.Distance(transform.position, closest.transform.position);
                    
                }
            }
        }
    }
    void shootKnuckles()
    {
        Rigidbody clone;
        
        clone = Instantiate(bullet, transform.position , transform.rotation) as Rigidbody;
        
        clone.velocity = transform.TransformDirection(Vector3.forward * 10);

    }
}
