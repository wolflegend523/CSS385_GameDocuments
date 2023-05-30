using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    Vector3[] currentPath;
    int currentIndex = 0;

    bool active;

    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (MoveToPoint(currentPath[currentIndex], 0.05f))
            {
                currentIndex++;
                if (currentIndex >= currentPath.Length)
                {
                    active = false;
                }
            }
        }

    }

    bool MoveToPoint(Vector3 point, float accuracy)
    {

        Vector3 direction = point - transform.position;

        direction = direction.normalized;
        /*if (direction.magnitude > 1)
        {
            direction = direction.normalized;
        }*/

        transform.position += direction*speed*Time.deltaTime;

        //transform.position = Vector3.Lerp(transform.position, point, speed * Time.deltaTime);

        if ((point - transform.position).magnitude < accuracy)
        {
            transform.position = point;
            return true;
        }

        return false;
    }
    public void MoveUsingPathfinding(PathfindResults pathfindResults, Vector3 location, out int movesUsed)
    {

        movesUsed = -1;

        PathfindNode node = pathfindResults.GetNodeAt(location);
        if (node == null)
        {
            return;
        }

        active = true;
        currentIndex = 0;
        currentPath = node.getPath();

        movesUsed = currentPath.Length - 1;
    }

    public bool isActive()
    {
        return active;
    }
}
