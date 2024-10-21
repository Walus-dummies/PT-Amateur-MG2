using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavigationComponent : MonoBehaviour
{
    // Variables publicas
    public NavMeshAgent agent;

    // Variables privadas;
    private float originalSpeed;

    private void Start()
    {
        originalSpeed = agent.speed;
    }

    public void MoveToPosition(Vector3 _targetPosition)
    {
        agent.destination = _targetPosition;
    }

    public void NavigationState(bool _state)
    {
        if (_state)
        {
            agent.speed = originalSpeed;
        }
        else
        {
            agent.speed = 0f;
        }
    }
}
