using UnityEngine;

public class Dot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectPoint();
        }
    }

    void CollectPoint()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1);
            }

            Debug.Log("Point collected!");
            Destroy(gameObject);
        }
}