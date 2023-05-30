using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAgent : PathfindAgent
{
    public override bool IsNodeValid(PathfindNode node)
    {
        if (obstacleAt(node.position))
        {
            return false;
        }
        return base.IsNodeValid(node);
    }
}
