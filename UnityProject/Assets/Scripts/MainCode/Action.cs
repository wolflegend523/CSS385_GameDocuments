using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    protected Character character;
    private void Start()
    {
        character = GetComponent<Character>();
    }

    //Perform the action without a specified location
    public virtual void Perform() { }
    //Perform world action at the specific location
    public virtual void Perform(Vector3 target) { }
    public abstract void Show();
    public abstract void Hide();

    public virtual void ShowUpdate()
    {

    }
    public abstract void OnActive();
    public abstract bool IsDone();

    public abstract bool IsExhausted();

    public virtual AITurn[] getAITurns()
    {
        return new AITurn[0];

    }




}
