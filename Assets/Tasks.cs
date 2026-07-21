using UnityEngine;
using TMPro;

public class Tasks : MonoBehaviour
{
    public static Tasks Instance; 

    private TextMeshProUGUI taskText; 

    // Prati jesu li zadaci ispunjeni
    private bool pointsTaskDone = false;
    private bool keyTaskDone = false;
    private bool exitTaskDone = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        // Skripta sama uzima TextMeshPro komponentu s istog objekta
        taskText = GetComponent<TextMeshProUGUI>();

        if (taskText == null)
        {
            Debug.LogError("Greska: Skripta je na objektu, ali nema TextMeshPro komponente!");
            return;
        }

        UpdateTaskUI(); 
    }

    // Funkcija koja crta zadatke na ekranu
    public void UpdateTaskUI()
    {
        string text = "<color=#FFFF00>TASKS:</color>\n";

        // 1. ZADATAK
        if (pointsTaskDone)
            text += "<s>- Collect all 160 points</s>\n";
        else
            text += "- Collect all 160 points\n";

        // 2. ZADATAK
        if (keyTaskDone)
            text += "<s>- Collect the key from the safe room</s>\n";
        else
            text += "- Collect the key from the safe room\n";

        // 3. ZADATAK
        if (exitTaskDone)
            text += "<s>- Find the exit door</s>\n";
        else
            text += "- Find the exit door\n";

        taskText.text = text; 
    }

    // --- FUNKCIJE ZA KRIŽANJE ZADATAKA (Pozivaš ih iz drugih skripti) ---

    // Pozovi ovo kada igrač skupi 160 bodova
    public void CompletePointsTask()
    {
        if (!pointsTaskDone)
        {
            pointsTaskDone = true;
            UpdateTaskUI();
        }
    }

    // Pozovi ovo kada igrač uzme ključ
    public void CompleteKeyTask()
    {
        if (!keyTaskDone)
        {
            keyTaskDone = true;
            UpdateTaskUI();
        }
    }

    // Pozovi ovo kada igrač nađe izlaz
    public void CompleteExitTask()
    {
        if (!exitTaskDone)
        {
            exitTaskDone = true;
            UpdateTaskUI();
        }
    }

        // Funkcija koja potpuno skriva zadatke s ekrana
    public void HideTasks()
    {
        gameObject.SetActive(false);
    }
}