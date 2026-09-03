using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public abstract class Ghost : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected Transform player;
    protected Player playerScript;

    public float updateRate = 0.2f;
    private float timer;

    public Transform homePoint;
    private Renderer ghostRenderer;

    public float normalSpeed = 3.5f;     // Brzina kojom duh inače hoda
    public float aggressiveSpeed = 5.5f; // Brzina kad igrač uzme ključ (Blinky mod)

    public int pointsToWakeUp; // Koliko bodova igrač mora imati da se ovaj duh probudi
    private bool isAwake = false; // Prati je li se duh već probudio


    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ghostRenderer = GetComponentInChildren<Renderer>();
        
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        playerScript = player?.GetComponent<Player>();

        if (GhostManager.Instance != null)
            GhostManager.Instance.RegisterGhost(this);
        
        if (agent != null)
        {
            agent.speed = normalSpeed;
        }
    }


    protected virtual void Update()
    {
        if (!isAwake)
        {
            if (GameManager.Instance != null && GameManager.Instance.score >= pointsToWakeUp)
            {
                isAwake = true;
                GameManager.Instance.ShowSpawnMessage(gameObject.name); // Ispisuje se poruka
            }
            else
            {
                if (homePoint != null)
                {
                    agent.SetDestination(homePoint.position);
                }
                return; 
            }
        }

        //ako je igrac u saferoomu ili nevidljiv duh se vraca na home point
        if (playerScript != null && (playerScript.isSafe || playerScript.isInvisible)) 
        {
            if (homePoint != null)
            {
                agent.SetDestination(homePoint.position);
            }
            return; 
        }

        //za ganjanje playera
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            UpdateDestination(); 
            timer = updateRate;
        }
    }
    protected abstract void UpdateDestination();


    public void SetAggressiveMode(bool startAggressive)
    {
        if (agent != null)
        {
            agent.speed = startAggressive ? aggressiveSpeed : normalSpeed;
            
            Debug.Log(gameObject.name + " speed changed to: " + agent.speed);
        }
    }
}