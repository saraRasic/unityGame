using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TMP_Text scoreTMP;
    public List<Ghost> ghosts;
    public Chest chest; 
    public GameObject winScreen;
    public GameObject gameOverScreen; 
    public GameObject powerPelletObject;
    public GameObject portalVrata; 
    public TextMeshProUGUI notificationText; 

    [SerializeField] private AudioClip chestOpenSound;
    [Range(0f, 1f)] [SerializeField] private float chestVolume = 0.6f;

    [Header("Music Settings")]
    public AudioSource initialBGM;     // Stara/početna glazba u igri
    public AudioSource bgmAudioSource; // Nova glazba koja svira kad se uzme ključ

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;

        foreach (Ghost g in ghosts)
        {
            if (g != null)
            {
                g.gameObject.SetActive(false);
            }
        }

        if (powerPelletObject != null)
        {
            powerPelletObject.SetActive(false);
        }  
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (scoreTMP != null)
        {
            scoreTMP.text = "Score : " + score + " / 160";
        }
        else
        {
            Debug.LogWarning("scoreTMP not assigned in GameManager!");
        }

        CheckGhostActivation();

        if (score >= 160)
        {
            WinGame();
            if (Tasks.Instance != null) Tasks.Instance.CompletePointsTask();
        }
    }

    void WinGame()
    {
        Debug.Log("You've collected all the points and won the game!");

        if (chestOpenSound != null && Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(chestOpenSound, Camera.main.transform.position, chestVolume);
        }

        foreach (Ghost g in ghosts)
        {
            if (g != null)
            {
                g.gameObject.SetActive(false);
            }
        }

        if (chest != null)
        {
            chest.Unlock();
        }
    }   

    void CheckGhostActivation()
    {
        if (score >= 40) ActivateGhost(0);  // Clyde
        if (score >= 80) ActivateGhost(1);  // Inky
        if (score >= 120) ActivateGhost(2); // Pinky
        if (score >= 140) ActivateGhost(3); // Blinky

        if (score >= 40 && powerPelletObject != null)
        {
            if (!powerPelletObject.activeSelf)
            {
                powerPelletObject.SetActive(true);
                Debug.Log("PowerPellet appeared on the map");
            }
        }
    }

    void ActivateGhost(int index)
    {
        if (index < ghosts.Count && ghosts[index] != null)
        {
            if (!ghosts[index].gameObject.activeSelf)
            {
                ghosts[index].gameObject.SetActive(true);
                ghosts[index].enabled = true;
                Debug.Log(ghosts[index].name + " is now active");
            }
        }
    }

    public void PlayerWon()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true); 
            if (Tasks.Instance != null) 
            {
                Tasks.Instance.HideTasks(); 
            }
        }

        // Zaustavljamo pozadinsku glazbu
        if (initialBGM != null) initialBGM.Stop();
        if (bgmAudioSource != null) bgmAudioSource.Stop();

        StopAllGhostSounds();

        if (portalVrata != null)
        {
            portalVrata.SetActive(false);
        }
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var movementScript = player.GetComponent<MonoBehaviour>(); 
            if (movementScript != null) movementScript.enabled = false;
        }

        foreach (Ghost g in ghosts)
        {
            if (g != null)
            {
                g.gameObject.SetActive(false); 
            }
        }

        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }

    // game over funkcija 
    public void GameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            if (Tasks.Instance != null) 
            {
                Tasks.Instance.HideTasks(); 
            }
        }

        // Zaustavljamo pozadinsku glazbu
        if (initialBGM != null) initialBGM.Stop();
        if (bgmAudioSource != null) bgmAudioSource.Stop();

        StopAllGhostSounds();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var movementScript = player.GetComponent<MonoBehaviour>();
            if (movementScript != null) movementScript.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }

    private void StopAllGhostSounds()
    {
        foreach (Ghost g in ghosts)
        {
            if (g != null)
            {
                // Zaustavlja AudioSource komponente ako ih duh ima na sebi
                AudioSource[] ghostAudioSources = g.GetComponents<AudioSource>();
                foreach (AudioSource audio in ghostAudioSources)
                {
                    audio.Stop();
                }

                // Dodatno zaustavlja zvukove i ako se nalaze na djeci (child objektima) duha
                AudioSource[] childAudioSources = g.GetComponentsInChildren<AudioSource>();
                foreach (AudioSource audio in childAudioSources)
                {
                    audio.Stop();
                }
            }
        }
    }

    public void MakeGhostsAggressive()
    {
        Debug.Log("Key collected! Making ghosts aggressive and faster");

        foreach (Ghost g in ghosts)
        {
            if (g != null)
            {
                g.gameObject.SetActive(true);
                g.enabled = true;
                g.SetAggressiveMode(true);
            }
        }

        if (initialBGM != null)
        {
            initialBGM.Stop(); 
        }

        if (bgmAudioSource != null)
        {
            bgmAudioSource.Play(); 
        }
    }

    public void ShowSpawnMessage(string ghostName)
    {
        if (notificationText != null)
        {
            notificationText.text += ghostName + " spawned!\n";
            CancelInvoke("ClearNotificationText"); 
            Invoke("ClearNotificationText", 3f);
        }
    }

    void ClearNotificationText()
    {
        if (notificationText != null)
        {
            notificationText.text = ""; 
        }
    }
}