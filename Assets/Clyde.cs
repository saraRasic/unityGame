using UnityEngine;

public class Clyde : Ghost
{
    //ovaj duh ganja igraca dok mu se ne priblizi i cim dode dovoljno blizu bjezi na svoj homepoint
    public float scatterDistance = 8f; //udaljenost od igraca na kojoj krene bjezati

    protected override void UpdateDestination()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > scatterDistance)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (homePoint != null)
            {
                agent.SetDestination(homePoint.position);
            }
            else
            {
                Debug.LogWarning("No homepoint assigned");
                agent.SetDestination(transform.position); //ostaje na mjestu ako nema homepoint
            }
        }
    }
}