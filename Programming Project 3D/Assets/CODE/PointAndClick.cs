using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
    private void Update()
    {
        NavMeshAgent _navAgent;
        _navAgent = GetComponent<NavMeshAgent>();

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000, _navAgent.areaMask))
            {
                _navAgent.SetDestination(hit.point);
            }
        }
    }
}



