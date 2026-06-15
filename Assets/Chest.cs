using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool isLocked = true;
    public GameObject closedVisual; 
    public GameObject openedVisual; 

    void Start()
    {
        if (closedVisual != null) closedVisual.SetActive(true);
        if (openedVisual != null) openedVisual.SetActive(false);
    }

    public void Unlock()
    {
        isLocked = false;
        Debug.Log("Chest is unlocked");
        
        if (closedVisual != null) closedVisual.SetActive(false);
        if (openedVisual != null) openedVisual.SetActive(true);
    }
}