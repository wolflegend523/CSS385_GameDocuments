using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] int health;

    int armor;
    int actionPoints;
    int movementPoints;

    [SerializeField] int movementPointsPerTurn;
    [SerializeField] int actionPointsPerTurn;
    [SerializeField] int armorPerTurn;

    [SerializeField] Sprite portait;
    [SerializeField] string characterName;

    public int GetArmor()
    {
        return armor;
    }

    public int GetArmorPerTurn()
    {
        return armorPerTurn;
    }

    public Sprite GetPotrait()
    {
        return portait;
    }

    public string GetName()
    {
        return characterName;
    }

    public void Refresh()
    {
        actionPoints = actionPointsPerTurn;
        movementPoints = movementPointsPerTurn;
        armor = armorPerTurn;
    }

    public void Exhaust()
    {
        actionPoints = 0;
        movementPoints = 0;
    }

    public int GetHealth()
    {
        return health;
    }

    public void AddHealth(int amount)
    {
        health += amount;
    }

    public bool isDead()
    {
        return (health <= 0);
    }

    public void TakeDamage(int amount)
    {
        while (armor != 0 && amount != 0)
        {
            armor--;
            amount--;
        }

        health += -amount;

        if (health < 0)
        {
            health = 0;
        }
    }

    public int GetActionPoints()
    {
        return actionPoints;
    }

    public void AddActionPoints(int amount)
    {
        actionPoints += amount;
    }
    public int GetMovementPoints()
    {
        return movementPoints;
    }

    public void AddMovementPoints(int amount)
    {
        movementPoints += amount;
    }

}
