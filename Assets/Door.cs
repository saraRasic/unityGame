using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject closedVisual; 
    public GameObject openedVisual; 
    public GameObject exit;

    private AudioSource portalAudio;

    void Start()
    {
        if (closedVisual != null) closedVisual.SetActive(true);
        if (openedVisual != null) openedVisual.SetActive(false);

        // Kod traži AudioSource na objektu koji glumi otvorena vrata
        if (openedVisual != null)
        {
            portalAudio = openedVisual.GetComponent<AudioSource>();
        }
        
        // Ako ga slučajno nema tamo, provjeri samog sebe za svaki slučaj
        if (portalAudio == null)
        {
            portalAudio = GetComponent<AudioSource>();
        }
    }

    public void OpenDoor()
    {
        Debug.Log("Door is opened");
        
        if (closedVisual != null) closedVisual.SetActive(false);
        if (openedVisual != null) openedVisual.SetActive(true);
        if (exit != null) exit.SetActive(true);

        if (portalAudio != null)
        {
            portalAudio.Play();
            Debug.Log("Portal sound started playing at: " + portalAudio.gameObject.name);
        }
    }
}