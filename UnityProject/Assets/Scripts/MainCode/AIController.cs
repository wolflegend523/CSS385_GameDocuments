using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
    }

    [SerializeField] AIThinkingIcon thinkingIcon;

    Character selected;
    bool done;
    public override void OnActive()
    {
        if (thinkingIcon.IsActive())
        {
            return;
        }
        if (!done)
        {
            if (!selected.IsActionActive())
            {
                selected.CalculateAI();
                AITurn bestTurn = selected.GetBestTurn();

                if (bestTurn != null)
                {
                    Debug.Log("Performing Turn: " + bestTurn.action.GetType());

                    if (bestTurn is AITurnWorld)
                    {
                        Debug.Log("at " + (bestTurn as AITurnWorld).position);
                    }
                    bestTurn.Perform();
                }
                else
                {
                    done = true;
                }
            }
        }
    }

    Character SelectBestCharacter()
    {
        Character bestCharacter = null;
        AITurn bestTurn = null;
        foreach (Character character in controlledCharacters)
        {
            AITurn characterTurn = character.GetBestTurn();
            if (characterTurn != null)
            {
                if (bestCharacter == null || bestTurn.weight < characterTurn.weight)
                {
                    bestCharacter = character;
                    bestTurn = characterTurn;
                }
            }
            selected = character;
        }

        return bestCharacter;

    }

    public override bool IsDone()
    {
        return done;
    }

    public override void OnStartTurn()
    {

        thinkingIcon.StartIcon();

        foreach (Character character in controlledCharacters)
        {
            character.CalculateAI();
        }

        selected = SelectBestCharacter();

        Debug.Log(selected);
        done = (selected == null);

    }
}
