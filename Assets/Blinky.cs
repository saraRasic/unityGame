public class Blinky : Ghost
{
    //ovaj duh ide direktno na igraca cijelo vrijeme
    protected override void UpdateDestination()
    {
        if (player != null)
            agent.SetDestination(player.position);
    }
}