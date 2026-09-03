using UnityEngine;

public class Dot : MonoBehaviour
{
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