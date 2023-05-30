using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [SerializeField] protected Character[] controlledCharacters;
    protected bool active;

    protected bool IsControlled(Character character)
    {
        foreach (Character controlledCharacter in controlledCharacters)
        {
            if (controlledCharacter == character)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsExhausted()
    {
        foreach (Character character in controlledCharacters)
        {
            if (!character.IsExhausted())
            {
                return false;
            }
        }
        return true;
    }

    public void OnStartRound()
    {
        foreach (Character character in controlledCharacters)
        {
            character.OnStartRound();
            character.GetStats().Refresh();
        }
    }


    public abstract void OnStartTurn();

    public abstract void OnActive();

    public abstract bool IsDone();
}
