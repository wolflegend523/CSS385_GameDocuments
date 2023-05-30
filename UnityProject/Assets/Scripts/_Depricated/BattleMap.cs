using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMap : MonoBehaviour
{
    private GridObject[,] tiles;

    public GridObject GetObject(int x, int y)
    {
        return null;
        //get an object at x and y,
        //bounds checking!

        //if there is no object in the array at point, return an AirObject
    }

    public GridObject[] GetObjectsRadius(int x, int y, int radius)
    {
        return null;
        //return an array of all objects within a radius of Wx,y
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
