using UnityEngine;

public class GhostCollision : MonoBehaviour
{
    private Ghost ghost;

    void Awake()
    {
        ghost = GetComponent<Ghost>();
        if (ghost == null)
        {
            Debug.LogError($"{name}: Ghost missing!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Player player = other.GetComponent<Player>();

        if (player != null && ghost != null)
        {
            //ako je igrac nevidljiv
            if (player.isInvisible)
            {
                Debug.Log(ghost.name + " cant see you");
            }
            //ako je igrac vidljiv
            else
            {
                Debug.Log("Ghost " + ghost.name + " caught you");
            }
        }
    }

}