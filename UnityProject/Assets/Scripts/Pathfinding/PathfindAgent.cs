using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PathfindAgent : MonoBehaviour
{

    GameObject[] infoObjects = new GameObject[0];

    [SerializeField] GameObject movementInfoPrefab;

    PathfindResults pathfindResults;

    int PathfindMaxCost = 1000;

    public void SetMaxCost(int newCost)
    {
        PathfindMaxCost = newCost;
    }

    public void Pathfind()
    {
        pathfindResults = new PathfindResults(gameObject.transform.position, this);
    }

    public PathfindResults GetPathfindResults()
    {
        return pathfindResults;
    }

    public PathfindResults UpdateInfo()
    {
        ClearInfo();


        PathfindNode[] nodes = pathfindResults.getNodes();

        infoObjects = new GameObject[nodes.Length];

        for (int i = 0; i < nodes.Length; i++)
        {
            GameObject nodeText = GameObject.Instantiate(movementInfoPrefab);

            nodeText.GetComponent<MovementInfo>().UpdateDisplay(nodes[i]);

            infoObjects[i] =nodeText;
        }

        return pathfindResults;
    }

    public void ClearInfo()
    {
        foreach (GameObject infoObject in infoObjects)
        {
            GameObject.Destroy(infoObject);
        }
        infoObjects = new GameObject[0];
    }





    public virtual bool IsNodeValid(PathfindNode node)
    {
        if (!tileExists(node.position))
        {
            return false;
        }

        if (node.cost > PathfindMaxCost)
        {
            return false;
        }

        return true;
    }
    protected bool obstacleAt(Vector3 position)
    {
        Obstacle result = GameUtils.GetComponentAt<Obstacle>(position);

        return (result != null);

    }

    protected bool tileExists(Vector3 position)
    {
        BackgroundTile result = GameUtils.GetComponentAt<BackgroundTile>(position);

        return (result != null);
    }
}
