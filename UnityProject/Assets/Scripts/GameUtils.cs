using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtils
{

    static int DefaultLayerMask()
    {
        return Physics2D.DefaultRaycastLayers;
    }

    #region Single GameObject Getters
    //Returns a single gameObject at a specified point
    public static GameObject GetGameObjectAt(Vector3 position)
    {
        return GetGameObjectAt(position, DefaultLayerMask());
    }

    //Returns a single gameObject at a specified point
    public static GameObject GetGameObjectAt(Vector3 position, params string[] layer)
    {
        int layerMask = LayerMask.GetMask(layer);

        return GetGameObjectAt(position, layerMask);
    }

    //Returns a single gameObject at a specified point
    public static GameObject GetGameObjectAt(Vector3 position, int layerMask)
    {
        Collider2D collider = Physics2D.OverlapPoint(position, layerMask);

        if (collider == null)
        {
            return null;
        }

        return collider.gameObject;
    }
    #endregion
    #region Array GameObject Getters
    //Returns an array of the gameObjects at a specified point
    public static GameObject[] GetGameObjectsAt(Vector3 position)
    {
        return GetGameObjectsAt(position, DefaultLayerMask());
    }

    //Returns an array of the gameObjects at a specified point with the specified layer
    public static GameObject[] GetGameObjectsAt(Vector3 position, params string[] layer)
    {
        int layerMask = LayerMask.GetMask(layer);

        return GetGameObjectsAt(position, layerMask);
    }

    public static GameObject[] GetGameObjectsAt(Vector3 position, int layerMask)
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(position, layerMask);

        GameObject[] gameObjects = new GameObject[colliders.Length];

        for (int i = 0; i < colliders.Length; i++)
        {
            gameObjects[i] = colliders[i].gameObject;
        }
        return gameObjects;

    }

    #endregion

    #region Single Component Getters
    public static T GetComponentAt<T>(Vector3 position) where T : Component
    {
        return GetComponentAt<T>(position, DefaultLayerMask());
    }

    public static T GetComponentAt<T>(Vector3 position, params string[] layer) where T : Component
    {
        int layerMask = LayerMask.GetMask(layer);

        return GetComponentAt<T>(position, layerMask);
    }

    public static T GetComponentAt<T>(Vector3 position, int layerMask) where T : Component
    {

        GameObject[] gameObjects = GetGameObjectsAt(position, layerMask);

        foreach (GameObject gameObject in gameObjects)
        {
            T result = gameObject.GetComponent<T>();
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

    #endregion
    #region Array Component Getters

    public static T[] GetComponentsAt<T>(Vector3 position) where T : Component
    {
        return GetComponentsAt<T>(position, DefaultLayerMask());
    }

    public static T[] GetComponentsAt<T>(Vector3 position, params string[] layer) where T : Component
    {
        int layerMask = LayerMask.GetMask(layer);

        return GetComponentsAt<T>(position, layerMask);
    }

    public static T[] GetComponentsAt<T>(Vector3 position, int layerMask) where T : Component
    {

        GameObject[] gameObjects = GetGameObjectsAt(position, layerMask);

        List<T> resultList = new List<T>();

        foreach (GameObject gameObject in gameObjects)
        {
            T result = gameObject.GetComponent<T>();
            if (result != null)
            {
                resultList.Add(result);
            }
        }

        return resultList.ToArray();
    }


    #endregion

    public static Vector3 GetMouseGridPosition()
    {
        return GetGridPosition(GetMousePosition());
    }

    public static Vector3 GetMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;

        return mousePos;
    }

    public static Vector3 GetGridPosition(Vector3 position)
    {
        Vector3 gridPosition = position;

        gridPosition += new Vector3(0.5f, 0.5f);

        gridPosition.x = Mathf.Floor(gridPosition.x);
        gridPosition.y = Mathf.Floor(gridPosition.y);

        return gridPosition;

    }

    public static float GetManhattanDistance(Vector3 v1, Vector3 v2)
    {
        Vector3 difference = v1 - v2;
        return (Mathf.Abs(difference.x) + Mathf.Abs(difference.y));
    }

}
