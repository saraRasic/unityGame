public class Blinky : Ghost
{
    protected override void UpdateDestination()
    {
        if (player != null)
            agent.SetDestination(player.position);
    }
}