using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AILogic : MonoBehaviour
{

    [SerializeField] Character character;
    public float CalculateClosestEnemyWeight(Vector3 position)
    {

        float closestDistance = -1;
        foreach (Character enemy in FindObjectsOfType<Character>())
        {
            if (character.GetController() != enemy.GetController())
            {
                float distance = GameUtils.GetManhattanDistance(position, enemy.transform.position);

                if (closestDistance == -1 || distance < closestDistance)
                {
                    closestDistance = distance;
                }
            }
        }

        if (closestDistance == 0)
        {
            return 0;
        }

        return (1.0f / closestDistance);
    }
}
