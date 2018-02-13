using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour {


    FindTheWay findTheWay;
    Vector3 targetDir;
	// Use this for initialization
	void Start () {
        findTheWay = GetComponentInParent<FindTheWay>();
	}
	
	// Update is called once per frame
	void Update () {

        float step = findTheWay.speed * Time.deltaTime;
        if (findTheWay.closest != null)
        { targetDir = findTheWay.closest.transform.position - transform.position; }

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        newDir.x = 0;
        newDir.z = 0;
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
