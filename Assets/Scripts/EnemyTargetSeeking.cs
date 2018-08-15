using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTargetSeeking : MonoBehaviour {

    public GameObject myTarget;
    NavMeshAgent thisAgent;

    private void Start()
    {
        thisAgent = gameObject.GetComponent<NavMeshAgent>();
        myTarget = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        thisAgent.destination = myTarget.transform.position; 
    }

}
