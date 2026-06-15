using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public static GhostManager Instance;

    private List<Ghost> allGhosts = new List<Ghost>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void RegisterGhost(Ghost ghost)
    {
        if (!allGhosts.Contains(ghost))
            allGhosts.Add(ghost);
    }
}