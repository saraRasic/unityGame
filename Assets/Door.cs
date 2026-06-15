using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject closedVisual; 
    public GameObject openedVisual; 
    public GameObject exit;

    void Start()
    {
        if (closedVisual != null) closedVisual.SetActive(true);
        if (openedVisual != null) openedVisual.SetActive(false);
    }

    public void OpenDoor()
    {
        Debug.Log("Door is opened");
        
        if (closedVisual != null) closedVisual.SetActive(false);
        if (openedVisual != null) openedVisual.SetActive(true);
        if (exit != null) exit.SetActive(true);
    }
}