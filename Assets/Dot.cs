using UnityEngine;

public class Dot : MonoBehaviour
{
    // 1. Ovdje dodajemo polje u koje ćeš ubaciti zvuk u Unityju
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectPoint();
        }
    }

    void CollectPoint()
    {
        // 2. Ako si ubacila zvuk, odsviraj ga na trenutnoj poziciji kuglice
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 0.1f);
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(1);
        }

        Debug.Log("Point collected!");
        Destroy(gameObject);
    }
}