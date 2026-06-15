using UnityEngine;

public class WinPanel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = FindFirstObjectByType<GameManager>();
            if (gm != null)
            {
                gm.PlayerWon();
            }
        }
    }
}