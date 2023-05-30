using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Single Getters----------------------
            //GetGameObjectExample();
            //GetGameObjectExampleCharacterOnly();
            //GetGameObjectExampleBackgroundOnly();

            //Array Getters-----------------------
            //GetGameObjectsExample();
            //GetGameObjectsExampleCharacterOnly();
            //GetGameObjectsExampleBackgroundOnly();

            //Component Getters-------------------
            GetCharacterExample();
            //GetCharacterArrayExample();
        }
    }

    void GetCharacterExample()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Character character = GameUtils.GetComponentAt<Character>(mousePos);

        if (character == null)
        {
            Debug.Log("No Character Found");
            return;
        }

        Debug.Log(character.name);
    }
    void GetCharacterArrayExample()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Character[] characters = GameUtils.GetComponentsAt<Character>(mousePos);

        foreach (Character character in characters)
        {
            Debug.Log(character.name);
        }
    }

    void GetGameObjectsExample()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject[] gameObjects = GameUtils.GetGameObjectsAt(mousePos);

        foreach (GameObject exampleGameObject in gameObjects)
        {
            Debug.Log(exampleGameObject.name);
        }
    }

    void GetGameObjectsExampleCharacterOnly()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject[] gameObjects = GameUtils.GetGameObjectsAt(mousePos, "Character");

        foreach (GameObject exampleGameObject in gameObjects)
        {
            Debug.Log(exampleGameObject.name);
        }
    }
    void GetGameObjectsExampleBackgroundOnly()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject[] gameObjects = GameUtils.GetGameObjectsAt(mousePos, "Background");

        foreach (GameObject exampleGameObject in gameObjects)
        {
            Debug.Log(exampleGameObject.name);
        }
    }

    void GetGameObjectExample()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //cannot name this "gameObject" because MonoBehaviour already has a class member "gameObject"
        GameObject exampleGameObject = GameUtils.GetGameObjectAt(mousePos);

        if (exampleGameObject == null)
        {
            Debug.Log("No GameObject Found");
            return;
        }

        Debug.Log(exampleGameObject.name);

    }

    void GetGameObjectExampleCharacterOnly()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //cannot name this "gameObject" because MonoBehaviour already has a class member "gameObject"
        GameObject exampleGameObject = GameUtils.GetGameObjectAt(mousePos, "Character");

        if (exampleGameObject == null)
        {
            Debug.Log("No GameObject Found");
            return;
        }

        Debug.Log(exampleGameObject.name);

    }
    void GetGameObjectExampleBackgroundOnly()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //cannot name this "gameObject" because MonoBehaviour already has a class member "gameObject"
        GameObject exampleGameObject = GameUtils.GetGameObjectAt(mousePos, "Character");

        if (exampleGameObject == null)
        {
            Debug.Log("No GameObject Found");
            return;
        }

        Debug.Log(exampleGameObject.name);
        

    }
}
