using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Shoot : MonoBehaviour {

    [Header("Gun Controls")]
    public float fireRate = 0.25f;                                   
    public float weaponRange = 20f;
    private float nextFire;

    [Space]

    [Header("Speacial Effects")]
    public Rigidbody bullet;
    public Transform gunEnd;
    public ParticleSystem muzzleFlash;
    


    public void Shooting()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Rigidbody clone;
           
            clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 50);
            //muzzleFlash.Play();
            //Vector3 rayOrigin = gunEnd.position;
            
        }
        
    }

    void SpawnDecal(RaycastHit hit, GameObject prefab)
    {
        GameObject spawnedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
        spawnedDecal.transform.SetParent(hit.collider.transform);
    }
}

