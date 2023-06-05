using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : Action
{
    [SerializeField] Character thisCharacter;
    [SerializeField] int maxDamage;
    [SerializeField] int minDamage;

    [SerializeField] Animator animator;

    [SerializeField] int range;

    [SerializeField] Sprite attackIcon;

    [SerializeField] SoundProfile attackSound;



    public string GetDamageString()
    {
        return minDamage + "-" + maxDamage;
    }

    public int GetRange()
    {
        return range;
    }

    [SerializeField] GameObject linePrefab;

    GameObject lineInstance;

    public override void ShowUpdate()
    {
        if (character.GetStats().GetActionPoints() == 0)
        {
            lineInstance.SetActive(false);
            return;
        }
        Vector3[] validTargets = GetValidTargets();

        Vector3 target = Vector3.zero;
        bool found = false;

        foreach (Vector3 possibleTarget in validTargets)
        {
            if (possibleTarget == GameUtils.GetMouseGridPosition())
            {
                found = true;
                target = possibleTarget; 
            }
        }


        if (found)
        {
            lineInstance.SetActive(true);
            Vector3[] path = new Vector3[2];
            path[0] = transform.position;
            path[1] = target;
            lineInstance.GetComponent<LineRenderer>().positionCount = path.Length;
            lineInstance.GetComponent<LineRenderer>().SetPositions(path);
        }
        else
        {
            lineInstance.SetActive(false);
        }
    }

    public override void Show()
    {
        if (character.GetStats().GetActionPoints() > 0)
        {
            foreach (Vector3 position in GetValidTargets())
            {
                CreateTextObjectAt(position);
            }
        }

        lineInstance = GameObject.Instantiate(linePrefab);
    }
    public override void Hide()
    {
        foreach (GameObject info in textObjects)
        {
            GameObject.Destroy(info);
        }
        textObjects.Clear();

        GameObject.Destroy(lineInstance);
        lineInstance = null;
    }

    public override bool IsDone()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return true;
        }
        return false;
    }

    public override void OnActive()
    {
    }

    public override AITurn[] getAITurns()
    {

        if (character.GetStats().GetActionPoints() == 0)
        {
            return new AITurn[0];
        }

        Vector3[] validTargets = GetValidTargets();
        AITurn[] result = new AITurn[validTargets.Length];

        for (int i = 0; i < validTargets.Length; i++)
        {
            AITurnWorld action = new AITurnWorld();

            action.action = this;
            action.position = validTargets[i];
            action.weight = 500;// - GameUtils.GetComponentAt<Character>(validTargets[i]).GetStats().GetHealth();


            result[i] = action;
        }

        return result;

    }

    Vector3[] GetValidTargets()
    {
        List<Vector3> validTargets = new List<Vector3>();

        for (int x = -range; x <= range; x++)
        {
            for (int y = -range; y <= range; y++)
            {
                Vector3 targetPosition = transform.position + new Vector3(x, y);
                if (IsValidTarget(targetPosition)) {
                    validTargets.Add(targetPosition);
                }
            }
        }

        return validTargets.ToArray();
    }
    public Vector3[] GetValidTargets(Vector3 center)
    {
        List<Vector3> validTargets = new List<Vector3>();

        for (int x = -range; x <= range; x++)
        {
            for (int y = -range; y <= range; y++)
            {
                Vector3 targetPosition = center + new Vector3(x, y);
                if (IsValidTarget(targetPosition,center))
                {
                    validTargets.Add(targetPosition);
                }
            }
        }

        return validTargets.ToArray();
    }

    bool IsValidTarget(Vector3 position, Vector3 currentPosition)
    {
        Vector3 difference = (position - currentPosition);

        float distance = Mathf.Abs(difference.x) + Mathf.Abs(difference.y);

        if (distance > range)
        {
            return false;
        }

        Character targetCharacter = GameUtils.GetComponentAt<Character>(position);

        if (targetCharacter == null)
        {
            return false;
        }

        if (targetCharacter.GetStats().GetHealth() <= 0)
        {
            return false;
        }

        if (character.GetController() == targetCharacter.GetController())
        {
            return false;
        }
        return true;
    }
    bool IsValidTarget(Vector3 position)
    {
        Vector3 difference = (position - transform.position);

        float distance = Mathf.Abs(difference.x) + Mathf.Abs(difference.y);

        if (distance > range)
        {
            return false;
        }

        Character targetCharacter = GameUtils.GetComponentAt<Character>(position);

        if (targetCharacter == null)
        {
            return false;
        }

        if (targetCharacter.GetStats().GetHealth() <= 0)
        {
            return false;
        }

        if (character.GetController() == targetCharacter.GetController())
        {
            return false;
        }
        return true;
    }

    public override void Perform(Vector3 target)
    {
        if (character.GetStats().GetActionPoints() <= 0)
        {
            return;
        }

        // check if in reach

        Character attackedCharacter = GameUtils.GetComponentAt<Character>(target);
        if (attackedCharacter == null)
        {
            return;
        }

        if (!IsValidTarget(attackedCharacter.transform.position))
        {
            Debug.Log("fail");
            return;
        }


        // attack

        animator.Play("Attack");

        SoundManager.Get().playSound(attackSound);

        IconManager.Get().CreateIcon(attackedCharacter.transform.position, attackIcon);

        int damage = Random.Range(minDamage, maxDamage);
        attackedCharacter.takeDamage(damage);

        this.character.GetStats().AddActionPoints(-1);
        GetComponent<Character>().SetActiveAction(this);
    }





    [SerializeField] GameObject infoPrefab;

    List<GameObject> textObjects = new List<GameObject>();

    void CreateTextObjectAt(Vector3 position)
    {
        Character character = GameUtils.GetComponentAt<Character>(position);

        string infoText = minDamage + "-" + maxDamage;
        if (character != null)// && thisCharacter.GetController() != character.GetController())
        {
            GameObject info = GameObject.Instantiate(infoPrefab);
            info.GetComponent<TextInfo>().SetPosition(position);

            info.GetComponent<TextInfo>().UpdateText(infoText);

            textObjects.Add(info);
        }
    }

    public override bool IsExhausted()
    {
        if (!IsDone())
        {
            return false;
        }
        return (character.GetStats().GetActionPoints() <= 0 || GetValidTargets().Length == 0);
    }
}
