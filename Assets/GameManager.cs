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
    public GameObject powerPelletObject;

    // --- NOVO: Polja za zvuk otvaranja škrinje ---
    [Header("Audio Settings")]
    [SerializeField] private AudioClip chestOpenSound;
    [Range(0f, 1f)] [SerializeField] private float chestVolume = 0.6f;


    //kako bi mogla pristupiti GameManageru iz drugih skripti (Singleton pattern)
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //deaktivira duhove u pocetku igre
    void Start()
    {
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
        }
    }

    void WinGame()
    {
        Debug.Log("You've collected all the points and won the game!");

        // --- NOVO: Puštanje zvuka škrinje na poziciji kamere (2D zvuk za igrača) ---
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
        if (score >= 40) ActivateGhost(0);  //Clyde
        if (score >= 80) ActivateGhost(1);  //Inky
        if (score >= 120) ActivateGhost(2); //Pinky
        if (score >= 150) ActivateGhost(3); //Blinky

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
            Time.timeScale = 0f; 
        }
    }

    public void MakeGhostsAggressive()
    {
        Debug.Log("Key collected! Making ghosts aggressive and faster");

        foreach (Ghost g in ghosts)
        {
            if (g != null)
            {
                // 1. Ponovno upali objekt duha u igri
                g.gameObject.SetActive(true);
                g.enabled = true;

                // 2. Prebaci ga u brzi/agresivni mod koji smo ranije napravili
                g.SetAggressiveMode(true);
            }
        }
    }
}