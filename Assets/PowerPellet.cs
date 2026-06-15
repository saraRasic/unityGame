using UnityEngine;

public class PowerPellet : MonoBehaviour
{
    public float invisibilityDuration = 15f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player p = other.GetComponent<Player>();
            if (p != null)
            {
                p.BecomeInvisible(invisibilityDuration);
            }
            
            Destroy(gameObject); 
        }
    }
}