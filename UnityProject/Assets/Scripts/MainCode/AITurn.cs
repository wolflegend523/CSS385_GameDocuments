using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurn
{

    public float weight;

    public Action action;


    public virtual void Perform()
    {
        action.Perform();
    }

}
