using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Player : MonoBehaviour
{
    //za kretanje igraca
    public float speed = 5f;
    public float gravity = 9.81f;
    private CharacterController chr;
    public Transform cameraTransform; 
    float xRotation = 0f;
    public float mouseSensitivity = 200f;
    private Vector3 lastPosition;
    public bool isMoving; 

    //za safe room
    public bool isSafe = false;

    //za nevidljivost igraca
    public bool isInvisible = false;
    private float invisibilityTimer = 0f;
    public TextMeshProUGUI invisibilityTimerText; 


    void Start()
    {
        chr = GetComponent<CharacterController>();
        lastPosition = transform.position;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleLook();      
        HandleMovement();  
        HandleStatus();    
    }

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //ogranicava rotaciju kamere da ne ide preko glave

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        move.y = -gravity / speed; 

        chr.Move(move * speed * Time.deltaTime);

        isMoving = (transform.position != lastPosition);
        lastPosition = transform.position;
    }

    void HandleStatus()
    {
        if (invisibilityTimer > 0)
        {
            invisibilityTimer -= Time.deltaTime;

            if (invisibilityTimerText != null)
            {
                invisibilityTimerText.gameObject.SetActive(true);
                invisibilityTimerText.text = "Invisible for: " + invisibilityTimer.ToString("F0") + "s";
            }

            if (invisibilityTimer <= 0)
            {
                isInvisible = false;
                if (invisibilityTimerText != null) {
                    invisibilityTimerText.gameObject.SetActive(false);
                }
                Debug.Log("Player is now visible");
            }
        }
    }

    // --- PROVJERI SUDARA (Safe Room i Duhovi) ---
    private void OnTriggerEnter(Collider other) 
    {
        // Za safe room
        if (other.CompareTag("SafeRoom")) 
        {
            isSafe = true;
        }

        // --- NOVO: Detekcija duha ---
        if (other.CompareTag("Ghost"))
        {
            // Duh te može ubiti SAMO ako nisi nevidljiva i ako nisi u Safe Roomu!
            if (!isInvisible && !isSafe)
            {
                Debug.Log("Duh je ulovio igrača!");

                // Pozivamo GameManager da upali Game Over panel i zaustavi igru
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.GameOver();
                }
            }
            else
            {
                Debug.Log("Duh te dotaknuo, ali si sigurna (Nevidljivost/SafeRoom)!");
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("SafeRoom")) isSafe = false;
    }

    public void BecomeInvisible(float duration) {
        isInvisible = true;
        invisibilityTimer = duration;
    }
}