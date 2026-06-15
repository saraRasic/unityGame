using UnityEngine;

public class Pinky : Ghost
{
    public float offsetDistance = 3f; //koliko polja ispred igraca cilja
    public float aggressiveRange = 4f; //na kojoj udaljenosti krece napadati

    protected override void UpdateDestination()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        //ako je blizu ide direktno na igraca
        if (distanceToPlayer < aggressiveRange)
        {
            agent.SetDestination(player.position);
        }
        else
        {   
            //ako je daleko od igraca pokusava doci ispred njega 
            Vector3 ahead = player.position + player.forward * offsetDistance;
            agent.SetDestination(ahead);
        }
    }
}