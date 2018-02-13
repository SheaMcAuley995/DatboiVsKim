using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject spawningKnuckles;
    public GameObject[] knuckles;
    public int AmountOfKnuckles;
    public int spawnCap;


    void Update ()
    {
        knuckles = GameObject.FindGameObjectsWithTag("Knuckles");
        AmountOfKnuckles = knuckles.Length;
        if (AmountOfKnuckles < spawnCap)
        {
            Instantiate(spawningKnuckles, transform.position, transform.rotation);
        }
	}
}
