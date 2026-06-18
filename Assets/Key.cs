using UnityEngine;

public class Key : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float floatAmplitude = 0.2f; 
    public float floatFrequency = 2f;    

    private Vector3 startPos;
    public Door door; 

    // --- NOVO: Polja za zvuk ključa i njegovu glasnoću ---
    [Header("Audio Settings")]
    [SerializeField] private AudioClip keyPickupSound;
    [Range(0f, 1f)] [SerializeField] private float volume = 0.5f;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // --- NOVO: Odsviraj zvuk na poziciji ključa prije uništenja ---
            if (keyPickupSound != null)
            {
                AudioSource.PlayClipAtPoint(keyPickupSound, transform.position, volume);
            }

            if(door != null)
            {
                door.OpenDoor();
            }

            // --- Pozivamo GameManager da ubrza i razljuti duhove ---
            if (GameManager.Instance != null)
            {
                GameManager.Instance.MakeGhostsAggressive();
            }

            Debug.Log("Key collected");
            
            Destroy(gameObject);
        }
    }
}