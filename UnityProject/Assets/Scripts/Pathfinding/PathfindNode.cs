using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindNode
{

    public Vector3 position;
    public int cost;
    public PathfindNode previous;

    //transitional tiles can be moved through, but not the final destination
    public bool transitional = false;

    public Vector3[] getPath()
    {
        Vector3[] result;
        if (previous == null)
        {
            result = new Vector3[1];
            result[0] = position;
        } else {
            Vector3[] previousPath = previous.getPath();
            result = new Vector3[previousPath.Length + 1];

            for (int i = 0; i < previousPath.Length; i++)
            {
                result[i] = previousPath[i];
            }
            result[result.Length - 1] = position;
        }
        return result;
    }

    public Vector3[] getPathTrimmed()
    {
        Vector3[] result;
        if (previous == null)
        {
            result = new Vector3[1];
            result[0] = position;
        }
        else
        {
            Vector3[] previousPath = previous.getPathTrimmed();

            if (previousPath.Length > 1)
            {
                int lastIndex = previousPath.Length - 1;

                Vector3 previousDirection = previousPath[lastIndex] - previousPath[lastIndex - 1];
                Vector3 currentDirection = position - previousPath[lastIndex];
                if (previousDirection.normalized == currentDirection.normalized)
                {
                    previousPath[lastIndex] = position;
                    return previousPath;
                }
            }

            result = new Vector3[previousPath.Length + 1];

            for (int i = 0; i < previousPath.Length; i++)
            {
                result[i] = previousPath[i];
            }
            result[result.Length - 1] = position;
        }
        return result;

    }

}
