using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnAction : Action
{
    
    [SerializeField] GameObject endTurnButtonPrefab;

    [SerializeField] Sprite icon;

    [SerializeField] SoundProfile endTurnSound;

    GameObject instance;
    public override void Hide()
    {
        if (instance != null)
        {
            GameObject.Destroy(instance);
            instance = null;
        }
    }
    public override void Show()
    {
        if (instance == null)
        {
            instance = GameObject.Instantiate(endTurnButtonPrefab);

            instance.GetComponentInChildren<Button>().onClick.AddListener(Perform);
        }
    }

    public override bool IsDone()
    {
        return true;
    }

    public override void Perform()
    {
        character.GetStats().Exhaust();
        character.SetActiveAction(this);
        IconManager.Get().CreateIcon(transform.position, icon);

        SoundManager.Get().playSound(endTurnSound);

    }

    public override bool IsExhausted()
    {
        return true;
    }

    public override void OnActive()
    {
    }

    public override AITurn[] getAITurns()
    {

        if (character.GetStats().GetMovementPoints() == 0 && character.GetStats().GetActionPoints() == 0)
        {
            return new AITurn[0];
        }

        AITurn[] result = new AITurn[1];

        result[0] = new AITurn();

        result[0].action = this;

        result[0].weight = 15 * GetComponent<AttackAction>().GetValidTargets(transform.position).Length;
        result[0].weight += GetComponent<AILogic>().CalculateClosestEnemyWeight(transform.position);
        result[0].weight += 0.001f;

        return result;
    }

}
