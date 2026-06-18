using UnityEngine;

public class PowerPellet : MonoBehaviour
{
    public float invisibilityDuration = 15f;

    // 1. Dodajemo polja za zvuk i glasnoću koja možeš namještati u Unityju
    [SerializeField] private AudioClip powerUpSound;
    [Range(0f, 1f)] [SerializeField] private float volume = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 2. Odsviraj zvuk na poziciji ove kuglice prije nego je uništiš
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