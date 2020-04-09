using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{

    private NavMeshAgent navAgent;
    private Transform currentTarget;

    // Start is called before the first frame update
    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentTarget != null)
        {
            navAgent.destination = currentTarget.position;
        }
    }

    public void MoveUnit(Vector3 dest)
    {
        currentTarget = null;
        navAgent.destination = dest;
    }

    public void SetNewTarget(Transform enemy)
    {
        currentTarget = enemy;
    }
}
