using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
    [SerializeField] PathfindAgent pathfindAgent;

    [SerializeField] Animator animator;

    [SerializeField] AttackAction attackAction;


    Vector3[] currentPath;
    int currentIndex = 0;

    [SerializeField] float speed;

    [SerializeField] SoundProfile footstepSound;
    [SerializeField] float footstepSoundDelay;

    public override void Perform(Vector3 target)
    {
        pathfindAgent.SetMaxCost(character.GetStats().GetMovementPoints());
        pathfindAgent.Pathfind();
        MoveUsingPathfinding(pathfindAgent.GetPathfindResults(), target, out int movesUsed);

        if (movesUsed == -1)
        {
            return;
        }



        character.GetStats().AddMovementPoints(-movesUsed);

        GetComponent<Character>().SetActiveAction(this);
    }

    public override AITurn[] getAITurns()
    {
        pathfindAgent.SetMaxCost(character.GetStats().GetMovementPoints());
        pathfindAgent.Pathfind();
        PathfindResults pathfind = pathfindAgent.GetPathfindResults();

        AITurn[] result = new AITurn[pathfind.getNodes().Length];


        for (int i = 0; i < result.Length; i++)
        {
            result[i] = GenerateAITurn(pathfind.getNodes()[i]);

        }

        return result;

    }

    AITurn GenerateAITurn(PathfindNode node)
    {
        AITurnWorld turn = new AITurnWorld();

        turn.action = this;
        turn.position = node.position;

        
        //float enemyWeight = 15 * attackAction.GetValidTargets(node.position).Length;

        turn.weight = GetComponent<AILogic>().CalculateClosestEnemyWeight(node.position);


        return turn;

    }


    [SerializeField] GameObject linePrefab;

    GameObject lineInstance;

    public override void ShowUpdate()
    {
        PathfindResults pathfind = pathfindAgent.GetPathfindResults();

        PathfindNode node = pathfind.GetNodeAt(GameUtils.GetMouseGridPosition());
        
        if (node != null)
        {
            lineInstance.SetActive(true);
            Vector3[] path = node.getPathTrimmed();
            lineInstance.GetComponent<LineRenderer>().positionCount = path.Length;
            lineInstance.GetComponent<LineRenderer>().SetPositions(path);
        }  else
        {
            lineInstance.SetActive(false);
        }
    }

    public override void Show()
    {

        pathfindAgent.SetMaxCost(character.GetStats().GetMovementPoints());

        lineInstance = GameObject.Instantiate(linePrefab);

        pathfindAgent.Pathfind();
        pathfindAgent.UpdateInfo();
    }
    public override void Hide()
    {
        pathfindAgent.ClearInfo();

        GameObject.Destroy(lineInstance);
        lineInstance = null;
    }

    float lastFootstepTime;
    public override void OnActive()
    {
        if (MoveToPoint(currentPath[currentIndex], 0.15f))
        {
            currentIndex++;
        }

        if (Time.time - lastFootstepTime > footstepSoundDelay)
        {
            lastFootstepTime = Time.time;
            SoundManager.Get().playSound(footstepSound);
        }

    }
    public override bool IsDone()
    {
        if (currentIndex >= currentPath.Length)
        {
            animator.Play("Idle");
            return true;
        }
        return false;
    }

    bool MoveToPoint(Vector3 point, float accuracy)
    {

        Vector3 direction = point - transform.position;

        direction = direction.normalized;


        animator.Play("Move");

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position += direction * speed * Time.deltaTime;

        if ((point - transform.position).magnitude < accuracy)
        {
            transform.position = point;
            return true;
        }

        return false;
    }

    void MoveUsingPathfinding(PathfindResults pathfindResults, Vector3 location, out int movesUsed)
    {

        movesUsed = -1;

        PathfindNode node = pathfindResults.GetNodeAt(location);
        if (node == null)
        {
            return;
        }

        currentIndex = 0;
        currentPath = node.getPath();

        movesUsed = currentPath.Length - 1;
    }

    public override bool IsExhausted()
    {
        return (character.GetStats().GetMovementPoints() <= 0);
    }
}

/*
    bool IsAdjacentToEnemy(Vector3 position)
    {
        return (IsEnemy(position + Vector3.left) ||
            IsEnemy(position + Vector3.right) || IsEnemy(position + Vector3.up) || IsEnemy(position + Vector3.down));
    }

    bool IsEnemy(Vector3 position)
    {
        Character character = GameUtils.GetComponentAt<Character>(position);
        if (character == this.character) { return false; } 
        return (character != null);
    }
*/
