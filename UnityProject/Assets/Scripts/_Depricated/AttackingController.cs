using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackingController : MonoBehaviour
{
    // a flag to track whether a player object has been clicked
    private bool playerClicked = false; 
    private bool enemyClicked = false; 
     
     
     // Start is called before the first frame update
    void Start()
    {
        hideText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!textHidden)
            {
                hideText();
                return;
            }

            if (attacker == null || defender == null)
            {
                getCharacterAtCursor();
            }

            if (attacker != null && defender != null)
            {
                Attack();
                attacker = null;
                defender = null;
            }
            //Component Getters-------------------
            //GetCharacterArrayExample();
        }
    }

    Character attacker;
    Character defender;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject attackerIcon;
    [SerializeField] GameObject defenderIcon;

    bool textHidden = false;

    void Attack()
    {
        //store this just so when the object is destroyed, it will still be okay
        //int newDefenderHealth = defender.Health - attacker.damage;

        string infoString = attacker.name + " Attacks " + defender.name;
        //string damageString = "For " + attacker.damage + " damage";
        //string healthString = defender.name + "'s health is now at " + newDefenderHealth;
        //text.text = infoString + '\n' + damageString + '\n' + healthString;
        textHidden = false;

        //defender.damageEnemy(attacker.damage);

    }

    void hideText()
    {
        text.text = "";
        textHidden = true;

        attackerIcon.SetActive(false);
        defenderIcon.SetActive(false);
    }
    
    void getCharacterAtCursor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Character clicked = GameUtils.GetComponentAt<Character>(mousePos);

        if (clicked == null)
        {
            return;
        }

        if (attacker == null)
        {
            attacker = clicked;

            attackerIcon.SetActive(true);
            attackerIcon.transform.position = attacker.transform.position;

            return;
        }

        if (defender == null)
        {
            if (attacker != clicked)
            {
                defender = clicked;

                defenderIcon.SetActive(true);
                defenderIcon.transform.position = defender.transform.position;
            }
            return;
        }

    }

    void GetCharacterArrayExample()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Character[] characters = GameUtils.GetComponentsAt<Character>(mousePos);
         

        foreach (Character character in characters)
        {
            //Player attacking the enemy
            if (character.CompareTag("Player")) // check if the clicked object is a player
            {
                playerClicked = true;
                Debug.Log("Player clicked: " + character.name);
            }
            else if (character.CompareTag("Enemy") && playerClicked) // check if the clicked object is an enemy and a player has been clicked before
            {

                // Get a reference to the player script and call its function
                Character player = character.GetComponent<Character>();
                if (player != null)
                {
                    //player.damageEnemy(player.damage);

                }

                playerClicked = false; // reset the flag
            
            }


            //Enemy attacking the player 
            if(character.CompareTag("Enemy"))
            {
                enemyClicked = true;
                Debug.Log("Enemy clicked: " + character.name);

            }
            else if (character.CompareTag("Player") && enemyClicked)
            {

                // Get a reference to the player script and call its function
                Character enemy = character.GetComponent<Character>();
                if (enemy != null)
                {
                    //enemy.damageEnemy(enemy.damage);
                }

                enemyClicked = false; // reset the flag

                
            }

        }
    }

}