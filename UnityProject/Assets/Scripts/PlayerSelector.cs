using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{

    [SerializeField] GameObject selector;
    SpriteRenderer selectorSpriteRenderer;


    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color characterColor = Color.white;


    [SerializeField] GameObject selected;

    [SerializeField] Character selectedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        selectorSpriteRenderer = selector.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = GameUtils.GetMouseGridPosition();

        selector.transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Character character = GameUtils.GetComponentAt<Character>(mousePosition);

            if (character != null)
            {
                selectedCharacter = character;
            }
            
        }

        if (selectedCharacter != null)
        {

            selected.SetActive(true);
            selected.transform.position = selectedCharacter.transform.position;

            selected.GetComponent<SpriteRenderer>().color = characterColor;
        }

    }
}
