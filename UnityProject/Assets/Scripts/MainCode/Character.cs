using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] Controller controller;

    Action current;

    [SerializeField] Animator animator;

    [SerializeField] Action[] actions;


    [SerializeField] CharacterStats stats;

    bool hasMoved;
    public CharacterStats GetStats()
    {
        return stats;
    }

    public Controller GetController()
    {
        return controller;
    }

    public void OnStartRound()
    {
        hasMoved = false;
    }

    public bool HasActed()
    {
        return hasMoved;
    }

    public void SetActiveAction(Action action)
    {
        hasMoved = true;
        current = action;
    }

    public void PerformAction(Vector3 location)
    {
        if (current == null)
        {
            foreach (Action action in actions)
            {
                action.Perform(location);
            }
        }
    }

    public bool IsExhausted()
    {

        if (stats.GetHealth() <= 0)
        {
            return true;
        }

        if (current != null)
        {
            return false;
        }

        foreach (Action action in actions)
        {
            if (!action.IsExhausted())
            {
                return false;
            }
        }

        return true;
    }

    public bool IsActionActive()
    {
        return (current != null);
    }

    public void takeDamage(int amount)
    {
        stats.TakeDamage(amount);

        //GameObject hitNumber = GameObject.Instantiate(hitNumberPrefab);
        //hitNumber.GetComponent<HitNumber>().SetNumber(-amount);
        //hitNumber.transform.position = transform.position;

        if (stats.GetHealth() <= 0)
        {
            animator.Play("Dead");
        }
        else
        {
            animator.Play("Hit");
        }



    }


    List<AITurn> possibleTurns = new List<AITurn>();

    public void CalculateAI()
    {
        possibleTurns.Clear();

        if (stats.GetHealth() <= 0)
        {
            return;
        }

        foreach (Action action in actions)
        {
            foreach (AITurn turn in action.getAITurns())
            {
                possibleTurns.Add(turn);
            }
        }


    }

    public AITurn GetBestTurn()
    {
        AITurn bestTurn = null;

        foreach (AITurn turn in possibleTurns)
        {
            Debug.Log("Considered Turn: " + turn.action + " cost:" + turn.weight);
            if (bestTurn == null || bestTurn.weight < turn.weight)
            {
                bestTurn = turn;
            }
        }
        return bestTurn;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current != null)
        {
            current.OnActive();
            if (current.IsDone())
            {
                current = null;
            }
        }
    }
}
