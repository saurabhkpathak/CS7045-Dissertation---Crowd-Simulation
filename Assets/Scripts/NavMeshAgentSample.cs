﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavMeshAgentSample : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
	System.Random r;
    float speedCache;
    ArrayList exits;
    // Use this for initialization
    void Start () {
		r = new System.Random ();
        agent = GetComponent<NavMeshAgent>();
		int rDest = r.Next (1, 11);
		agent.transform.position = GameObject.Find ("Destination " + rDest).GetComponent<Transform> ().position;
        speedCache = agent.speed;
        exits = new ArrayList();
        populateExits(exits);
    }
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(agent.transform.position, target.transform.position) < 1.5) {
			int rDest = r.Next (1, 11);
			target = GameObject.Find ("Destination " + rDest).GetComponent<Transform> ();
		}
        agent.SetDestination(target.position);
        if (Input.GetKeyDown("s")) {
            agent.speed = 0;
        }
        if (Input.GetKeyDown("m")) {
            agent.speed = speedCache;
        }
        if (Input.GetKeyDown("e")) {
            agent.speed = 0;
            //float nearestExit = Vector3.Distance(agent.transform.position);
        }
    }

    void populateExits(ArrayList exits)
    {
        int i = 1;
		GameObject exit = GameObject.Find ("Exit " + i);
		while (exit != null) {
			exits.Add (exit);
			i++;
			exit = GameObject.Find ("Exit " + i);
        }
    }

    float getNearestExit()
    {
        float minDistance = Mathf.Infinity;
		for (var i = 1; i <= exits.Count; i++) {
		}
        return minDistance;
    }
}
