using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchScript : MonoBehaviour {

    public GameObject bullet;
    public Rigidbody bulletrb;
    public float bulletspeed;
    public Transform closest = null;
    private RaycastHit ray;
    [SerializeField]
    private float SearchRadius;
	// Use this for initialization
	void Start () {
        //bulletrb = GetComponent<Rigidbody>(bullet);
		
	}
	
	// Update is called once per frame
	void Update () {

        searchSphere(transform.position, SearchRadius);
        shoot(transform.position, closest.position);

        //bool hitboi = Physics.Raycast(transform.position, closest.position - transform.position, out ray, 10);
        //if (hitboi)
        //{

        //}

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, SearchRadius);
    }



    void searchSphere(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        // Debug.Log("Being called");
        // int i = 0;'
        closest = null;
        float ClosestDis = 99999;
        foreach (Collider guyhit in hitColliders)
        {
            if(guyhit.tag == "Knuckles")
            {
                
                if (Vector3.Distance(transform.position, guyhit.transform.position) < ClosestDis)
                {
                    ClosestDis = Vector3.Distance(transform.position, guyhit.transform.position);
                    closest = guyhit.transform;

                    
                       

                    //spawnedArrow.GetComponent<Rigidbody>().AddForce(((enemy.transform.position - spawnedArrow.transform.position).normalized * projectileSpeed) * Time.deltaTime, ForceMode.Impulse);
                }
                
               
            }
           
        }
    }


    void shoot(Vector3 start, Vector3 end)
    {
        
        if (closest != null)
        {
            Rigidbody clone;
            clone = Instantiate(bullet.GetComponent<Rigidbody>(), transform.position, transform.rotation) as Rigidbody;

            Debug.DrawLine(transform.position, closest.position);
            bullet.GetComponent<Rigidbody>().AddForce(((closest.transform.position - bullet.transform.position).normalized * bulletspeed) * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
