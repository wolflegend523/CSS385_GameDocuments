using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisualizer : MonoBehaviour
{

    bool showing = false;

    public void Show()
    {
        Action[] possibleActions = GetComponents<Action>();

        if (!showing)
        {
            showing = true;


            foreach (Action action in possibleActions)
            {
                action.Show();
            }
        }

        foreach (Action action in possibleActions)
        {
            action.ShowUpdate();
        }
    }

    public void Hide()
    {
        if (showing)
        {
            showing = false;

            Action[] possibleActions = GetComponents<Action>();

            foreach (Action action in possibleActions)
            {
                action.Hide();
            }
        }

    }
}
