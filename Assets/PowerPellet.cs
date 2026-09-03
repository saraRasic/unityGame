using UnityEngine;

public class PowerPellet : MonoBehaviour
{
    public float invisibilityDuration = 15f;

    [SerializeField] private AudioClip powerUpSound;
    [Range(0f, 1f)] [SerializeField] private float volume = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (powerUpSound != null)
            {
                AudioSource.PlayClipAtPoint(powerUpSound, transform.position, volume);
            }

            Player p = other.GetComponent<Player>();
            if (p != null)
            {
                p.BecomeInvisible(invisibilityDuration);
            }
            
            Destroy(gameObject); 
        }
    }
}