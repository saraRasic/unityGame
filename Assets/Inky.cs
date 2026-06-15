using UnityEngine;

public class Inky : Ghost
{
    //ovaj duh pokušava doci ispred igraca
    public float flankDistance = 4f; //udaljenost na koju pokusava doci ispred igraca
    public float attackRange = 3.5f; //udaljenost na kojoj ide direktno u napad

    protected override void UpdateDestination()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        //ako je blizu ide direktno na igraca
        if (distanceToPlayer < attackRange)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            //kad je daleko od igraca pokusava doci ispred njega (desna prednja strana)
            Vector3 target = player.position + (player.right + player.forward).normalized * flankDistance;
            agent.SetDestination(target);

            //float strana = (Random.value > 0.5f) ? 1f : -1f; 

            //ako je strana 1, ide desno. Ako je -1, ide lijevo 
            //Vector3 target = player.position + (player.forward + player.right * strana).normalized * flankDistance;
            //agent.SetDestination(target);
        }
    }
}