using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindResults
{
    public PathfindResults(Vector3 source, PathfindAgent agent)
    {
        this.agent = agent;
        Pathfind(source);
    }

    PathfindAgent agent;
    PathfindNode[] nodes;

    public PathfindNode[] getNodes()
    {
        return nodes;
    }


    // determine if a selected tile is valid 
    public PathfindNode GetNodeAt(Vector3 clickedPosition)
    {
        // loop through and find the position
        for (int i = 0; i < nodes.Length; i++)
        {
            PathfindNode curr = nodes[i];
            //dist = Vector3.Distance(curr.position, clickedPosition);

            //if (dist < 0.01)

            if (clickedPosition == curr.position)
            {
                return curr;
            }

        }
        //displayPaths();
        // return the node
        return null;
    }


    void Pathfind(Vector3 source)
    {

        List<PathfindNode> openList = new List<PathfindNode>();
        List<PathfindNode> closedList = new List<PathfindNode>();


        PathfindNode initial = new PathfindNode();
        initial.position = source;
        initial.cost = 0;
        initial.transitional = true;

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

        nodes = CutTransitionalNodes(closedList);

    }


    PathfindNode[] CutTransitionalNodes(List<PathfindNode> list) 
    {
        List<PathfindNode> result = new List<PathfindNode>();
        foreach (PathfindNode node in list)
        {
            if (!node.transitional)
            {
                result.Add(node);
            }
        }
        return result.ToArray();
    }

    PathfindNode findLowestInOpenList(List<PathfindNode> openList)
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

    bool listContains(List<PathfindNode> list, Vector3 position)
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

    void generateNewNodesInOpenList(PathfindNode current, List<PathfindNode> openList, List<PathfindNode> closedList)
    {
        generateNewNodeInOpenList(current.position + Vector3.right, current, openList, closedList);
        generateNewNodeInOpenList(current.position + Vector3.left, current, openList, closedList);
        generateNewNodeInOpenList(current.position + Vector3.up, current, openList, closedList);
        generateNewNodeInOpenList(current.position + Vector3.down, current, openList, closedList);
    }

    void generateNewNodeInOpenList(Vector3 newPosition, PathfindNode previous, List<PathfindNode> openList, List<PathfindNode> closedList)
    {
        if (listContains(openList, newPosition) || listContains(closedList, newPosition))
        {
            return;
        }

        PathfindNode generatedNode = new PathfindNode();
        generatedNode.cost = previous.cost + 1;
        generatedNode.position = newPosition;
        generatedNode.previous = previous;

        if (!agent.IsNodeValid(generatedNode))
        {
            return;
        }

        openList.Add(generatedNode);

    }

    bool tileExists(Vector3 position)
    {
        BackgroundTile result = GameUtils.GetComponentAt<BackgroundTile>(position);

        return (result != null);
    }


    static bool obstacleAt(Vector3 position)
    {
        Obstacle result = GameUtils.GetComponentAt<Obstacle>(position);

        return (result != null);

    }

}
