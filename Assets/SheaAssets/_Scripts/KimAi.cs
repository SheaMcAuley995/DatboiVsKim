﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KimAi : MonoBehaviour {


    private GameObject player;
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;
    private RaycastHit[] targets;
    private float maxDistanceToCheck = 6.0f;
    private float currentDistance;
    private Vector3 checkDirection;

    [SerializeField]
    float SearchRadius = 0;


    public Transform pointA;
    public Transform pointB;
    public NavMeshAgent navMeshAgent;
    private int currentTarget;
    private float distanceFromTarget;
    private Transform[] waypoints = null;

    //public List<Transform> KnukList = new List<Transform>();

    private void Awake()
    {
        player = GameObject.FindWithTag("kim");
        animator = gameObject.GetComponent<Animator>();
        pointA = GameObject.Find("p1").transform;
        pointB = GameObject.Find("p2").transform;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
       
       
    
        waypoints = new Transform[2]
        {
            pointA,
            pointB
        };
        currentTarget = 0;
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }

    private void FixedUpdate()
    {
        //currentDistance = Vector3.Distance(player.transform.position, transform.position);
        //animator.SetFloat("distanceFromPlayer", currentDistance);


        //checkDirection = player.transform.position - transform.position;
        //ray = new Ray(transform.position, checkDirection);
        //if(Physics.Raycast(ray, out hit,maxDistanceToCheck))
        //{
        //    if(hit.collider.gameObject == player)
        //    {
        //        animator.SetBool("IsEnemyVisible", true);
        //    } else
        //    {
        //        animator.SetBool("IsEnemyVisible", false);
        //    }

        //    distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
        //    animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
        //}
    
      

    }

    public void SetNextPoint()
    {
        switch (currentTarget)
        {
            case 0:
                currentTarget = 1;
                break;
            case 1:
                currentTarget = 0;
                break;
        }

        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }

}
