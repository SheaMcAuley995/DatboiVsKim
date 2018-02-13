using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectKim : MonoBehaviour
{
    public float searchRad;

	void Start ()
    {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, searchRad);
    }
    void Update ()
    {
		
	}
}
