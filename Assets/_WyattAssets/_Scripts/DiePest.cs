using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePest : MonoBehaviour
{	

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
