using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapLevel : MonoBehaviour
{

    public int levelNumber;
    public WorldMapLevel[] adjacentLevels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // returns true if the given level is one of the levels 
    // adjacent to this level
    public bool isAdjacentTo(WorldMapLevel level) {
        foreach (WorldMapLevel item in adjacentLevels)
        {
            if (item == level) {
                return true;
            }
        }
        return false;
    }
}
