using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{ 
    Character selected;

    [SerializeField] CharacterInfoDisplay characterInfo;

    Character infoTarget;

    [SerializeField] GameObject selectObject;
    [SerializeField] GameObject infoObject;

    public override bool IsDone()
    {
        if (selected != null)
        {
            if (selected.IsExhausted())
            {
                selected.GetStats().Exhaust();
                selected.GetComponent<CharacterVisualizer>().Hide();


                selected = null;
                return true;
            }
        }
        return false;
    }

    public override void OnActive()
    {
        Select();

        if (selected != null)
        {
            if (selected.IsActionActive())
            {
                selected.GetComponent<CharacterVisualizer>().Hide();
            }
            else
            {
                selected.GetComponent<CharacterVisualizer>().Show();
            }
        }
    }
    
    public void Select()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool selectedNewCharacter = false;
            Character clicked = GameUtils.GetComponentAt<Character>(GameUtils.GetMousePosition());
            if (clicked != null && IsControlled(clicked) && !clicked.IsExhausted())
            {
                if (selected == null || !selected.HasActed())
                {
                    if (selected != null)
                    {
                        selected.GetComponent<CharacterVisualizer>().Hide();
                    }

                    selectedNewCharacter = true;
                    selected = clicked;
                }
            }
            if (!selectedNewCharacter && selected != null)
            {
                selected.PerformAction(GameUtils.GetMouseGridPosition());

            }
        }

    }

    public void SelectInfo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Character clicked = GameUtils.GetComponentAt<Character>(GameUtils.GetMousePosition());
            if (clicked != null)
            {
                infoTarget = clicked;
            }
        }

    }

    private void Update()
    {

        SelectInfo();

        if (infoTarget != null)
        {
            infoObject.SetActive(true);
            infoObject.transform.position = infoTarget.transform.position;
            characterInfo.SetCharacter(infoTarget);
        } else
        {
            infoObject.SetActive(false);
        }

        if (selected != null)
        {
            selectObject.SetActive(true);
            selectObject.transform.position = selected.transform.position;
        } else
        {
            selectObject.SetActive(false);
        }
    }

    public override void OnStartTurn()
    {
    }
}
