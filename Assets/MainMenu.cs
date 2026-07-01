using UnityEngine;
using UnityEngine.SceneManagement; // Obavezno za upravljanje scenama

public class MainMenu : MonoBehaviour
{
    // Ova funkcija će se pokrenuti kada igrač klikne gumb IGRAJ
    public void PlayGame()
    {
        // Učitava scenu s labirintom prema točnom imenu s tvoje slike
        SceneManager.LoadScene("Pacman Game"); 
    }

    // Ova funkcija će te vratiti na početni zaslon
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Pazi da se scena u Scenes mapi zove točno "MainMenu"
    }

    // Ova funkcija će ugasiti igru (radit će tek nakon što napraviš Build igre)
    public void QuitGame()
    {
        Debug.Log("Igra se gasi...");
        Application.Quit();
    }

    
}