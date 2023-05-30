using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurnWorld : AITurn
{

    public Vector3 position;

    public override void Perform()
    {
        action.Perform(position);
    }
}
