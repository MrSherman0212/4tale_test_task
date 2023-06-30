using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;

    public void Initialize()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(movePosition, out var hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
            }
        }
    }
}
