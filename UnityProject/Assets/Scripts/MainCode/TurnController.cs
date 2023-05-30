using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    [SerializeField] Controller[] controllers;
    [SerializeField] int current = -1;

    void StartRound()
    {
        
        foreach (Controller controller in controllers)
        {
            controller.OnStartRound();
        }
        current = 0;

        controllers[current].OnStartTurn();
    }

    void AdvanceTurn()
    {

        //controllers[current].OnEndTurn();
        current++;

        if (current >= controllers.Length)
        {
            current = 0;
        }

        if (NeedsRoundRestart())
        {
            StartRound();
        }

        controllers[current].OnStartTurn();
    }

    bool NeedsRoundRestart()
    {
        
        foreach (Controller controller in controllers)
        {
            if (!controller.IsExhausted())
            {
                return false;
            }
        }
        return true;

    }
    // Start is called before the first frame update
    void Start()
    {
        StartRound();
    }

    private void Update()
    {
        controllers[current].OnActive();
        if (controllers[current].IsDone() || controllers[current].IsExhausted())
        {

            AdvanceTurn();

        }
    }
}
