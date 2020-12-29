using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// unity automatically adds nav mesh agent when using this component
[RequireComponent(typeof(NavMeshAgent))] 
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
