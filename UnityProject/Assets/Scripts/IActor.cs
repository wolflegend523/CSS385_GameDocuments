using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{

    //called once when this actor is activated
    public void Activate();

    //called every frame when this actor is Active
    public void OnActive();

    //returns true if this actor should be deactivated
    public bool IsDone();
    //called once when this actor is deactivated
    public void Deactivate();


}
