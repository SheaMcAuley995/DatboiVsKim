using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    public void OnParticleTrigger()
    {
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject != null)
            Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        {
            if (other.tag == "Terrain")
            {
                Destroy(gameObject);
            }
            if (other.tag == "Knuckles")
            {
                Destroy(gameObject);
            }
        }
    }
}
