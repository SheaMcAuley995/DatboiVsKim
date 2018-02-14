
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheWay : MonoBehaviour
{
    Shoot myGun;

    public float SearchRadius;
    public Rigidbody bullet;
    public Transform closest = null;

    public GameObject explosionEffect;
    public float explosionForce;
    public float explosionRadius;

    public Vector3 targetDir;

    public float speed;

    void Start()
    {
        myGun = GetComponent<Shoot>();
    }

    // Update is called once per frame
<<<<<<< HEAD
    void Update()
    {
        float step = speed * Time.deltaTime;
        ExplosionDamage(transform.position, SearchRadius);

        if(closest != null)
        { targetDir = closest.transform.position - transform.position; }
        
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        

        

        //newDir.y = 0;
        transform.rotation = Quaternion.LookRotation(newDir);
      //  Debug.DrawLine(transform.position, closest.transform.position);
        myGun.Shooting();
        //shootKnuckles();
    }
=======
>>>>>>> 47502c7732c82a352062e0a5ccaa4378ffbb523e

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, SearchRadius);
    }

    public Transform findTarget(Vector3 center, float radius)
    {
        Transform retval = null;
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        
        float closestDist = 9999;
        
        foreach (Collider guyhit in hitColliders)
        {
           
            if (guyhit.tag == "Knuckles")
            {

                if (Vector3.Distance(transform.position, guyhit.transform.position) < closestDist)
                {
                    retval = guyhit.transform;
                    closestDist = Vector3.Distance(transform.position, closest.transform.position);
                    
                }
            }
        }
        return retval;
    }
    void shootKnuckles()
    {
        Rigidbody clone;
        
        clone = Instantiate(bullet, transform.position , transform.rotation) as Rigidbody;
        
        clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        
        
        
    }

    //void CheckExplosion()
    //{
    //    Collider[] CheckBoom = Physics.OverlapSphere();
    //    if (CheckBoom.Length >= 10)
    //    {

    //        Debug.Log("Nice");
    //    }
    //}

    void explosion()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 15);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Knuckles")
        {
            Destroy(gameObject);
        }
        
    }
}
