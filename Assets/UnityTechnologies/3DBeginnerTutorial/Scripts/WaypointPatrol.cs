using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    private int currentWaypointIndex;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component from the same game object
        currentWaypointIndex = 0; // Start at the first waypoint
        SetDestinationToWaypoint();
    }

    private void Update()
    {
        // Check if the agent has reached the current waypoint
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Move to the next waypoint

            SetDestinationToWaypoint(); // Set the destination to the new waypoint
        }
    }

    private void SetDestinationToWaypoint()
    {
        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}