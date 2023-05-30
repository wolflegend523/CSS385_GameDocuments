using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAgent : PathfindAgent
{
    public override bool IsNodeValid(PathfindNode node)
    {
        if (obstacleAt(node.position))
        {
            node.transitional = true;
        }

        return base.IsNodeValid(node);
    }

}
