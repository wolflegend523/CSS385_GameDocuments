using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindUtils
{
    /*
    static int max_pathfind_dist = 5;

    public static PathfindResults Pathfind(Vector3 source)
    {

        List<PathfindNode> openList = new List<PathfindNode>();
        List<PathfindNode> closedList = new List<PathfindNode>();


        PathfindNode initial = new PathfindNode();
        initial.position = source;
        initial.cost = 0;

        openList.Add(initial);

        while (true)
        {
            PathfindNode lowest = findLowestInOpenList(openList);

            if (lowest == null)
            {
                //done
                break;
            }

            openList.Remove(lowest);
            closedList.Add(lowest);

            generateNewNodesInOpenList(lowest, openList, closedList);


        }

        return new PathfindResults(closedList.ToArray());

    }

    static PathfindNode findLowestInOpenList(List<PathfindNode> openList)
    {
        PathfindNode lowest = null;
        foreach (PathfindNode node in openList)
        {
            if (lowest == null || node.cost < lowest.cost)
            {
                lowest = node;
            }
        }
        return lowest;
    }

    static bool listContains(List<PathfindNode> list, Vector3 position)
    {
        foreach (PathfindNode node in list)
        {
            if (node.position == position)
            {
                return true;
            }
        }
        return false;
    }

    static void generateNewNodesInOpenList(PathfindNode current, List<PathfindNode> openList, List<PathfindNode> closedList)
    {
        generateNewNodeInOpenList(current.position + Vector3.right, current, openList, closedList);
        generateNewNodeInOpenList(current.position + Vector3.left, current, openList, closedList);
        generateNewNodeInOpenList(current.position + Vector3.up, current, openList, closedList);
        generateNewNodeInOpenList(current.position + Vector3.down, current, openList, closedList);
    }

    static void generateNewNodeInOpenList(Vector3 newPosition, PathfindNode previous, List<PathfindNode> openList, List<PathfindNode> closedList)
    {
        if (listContains(openList, newPosition) || listContains(closedList, newPosition))
        {
            return;
        }

        if (!tileExists(newPosition))
        {
            return;
        }


        if (obstacleAt(newPosition))
        {
            return;
        }

        PathfindNode generatedNode = new PathfindNode();
        generatedNode.cost = previous.cost + 1;
        generatedNode.position = newPosition;
        generatedNode.previous = previous;

        if (!validNode(generatedNode))
        {
            return;
        }

        openList.Add(generatedNode);

    }

    static bool tileExists(Vector3 position)
    {
        BackgroundTile result = GameUtils.GetComponentAt<BackgroundTile>(position);

        return (result != null);
    }

    static bool obstacleAt(Vector3 position)
    {
        Obstacle result = GameUtils.GetComponentAt<Obstacle>(position);

        return (result != null);

    }

    static bool validNode(PathfindNode node)
    {
        if (node.cost <= max_pathfind_dist)
        {
            return true;
        }
        return false;
    }*/
}
