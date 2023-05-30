using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfoDisplay : MonoBehaviour
{
    [SerializeField] GameObject display;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] ActionPointDisplay actionPoints;

    [SerializeField] TextMeshProUGUI characterNameText;

    [SerializeField] GameObject meleeObject;
    [SerializeField] TextMeshProUGUI meleeDamageText;

    [SerializeField] GameObject rangedObject;
    [SerializeField] TextMeshProUGUI rangedDamageText;
    [SerializeField] TextMeshProUGUI rangeText;

    [SerializeField] GameObject armorObject;
    [SerializeField] TextMeshProUGUI armorText;

    Character currentCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetCharacter(Character character)
    {
        this.currentCharacter = character;
    }

    public void ClearCharacter()
    {
        this.currentCharacter = null;
    }

    void SetDisplay()
    {
        display.SetActive(true);

        image.sprite = currentCharacter.GetStats().GetPotrait();

        healthText.text = ": " + currentCharacter.GetStats().GetHealth();

        characterNameText.text = currentCharacter.GetStats().GetName();

         AttackAction attackAction = currentCharacter.GetComponent<AttackAction>();

        if (attackAction.GetRange() == 1)
        {
            rangedObject.SetActive(false);
            meleeObject.SetActive(true);
            meleeDamageText.text = ": " + attackAction.GetDamageString();
        } else
        {
            rangedObject.SetActive(true);
            meleeObject.SetActive(false);
            rangedDamageText.text = ": " + attackAction.GetDamageString();
            rangeText.text = ": " + attackAction.GetRange();


        }

        if (currentCharacter.GetStats().GetArmorPerTurn() == 0)
        {
            armorObject.SetActive(false);
        } else
        {
            armorObject.SetActive(true);
            armorText.text = ": " + currentCharacter.GetStats().GetArmor() + 
                "/" + currentCharacter.GetStats().GetArmorPerTurn();

        }


        actionPoints.SetDisplay(currentCharacter.GetStats().GetMovementPoints(), currentCharacter.GetStats().GetActionPoints());
    }

    void HideDisplay()
    {
        display.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentCharacter != null)
        {
           SetDisplay();
        } else
        {
            HideDisplay();
        }
    }
}
