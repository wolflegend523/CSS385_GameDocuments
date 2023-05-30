using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour
{

    protected BattleMap activeMap;

    public void SetBattleMap(BattleMap activeMap)
    {
        this.activeMap = activeMap;
    }
}
