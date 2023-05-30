using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundInfoText : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMesh;
    float alpha = 0;
    float timeSinceDisplayed = 0;
    float timeSinceDecrease = 0;
    float timeToDecrase = 0.01f;
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // increase variables
        timeSinceDecrease += Time.deltaTime;
        timeSinceDisplayed += Time.deltaTime;
        // if time, decrease alpha
        if (alpha > 0 && timeSinceDecrease >= timeToDecrase && timeSinceDisplayed > 1.5) {
            timeSinceDecrease = 0;
            alpha -= 0.01f;
            Color colorToTurnTo = new Color (1f, 1f, 1f, alpha);
            textMesh.color= colorToTurnTo;
        } 
    }

    public void display() {
        // set variables
        alpha = 1;
        timeSinceDisplayed = 0;
        timeSinceDecrease = 0;
        // make visible 
        Color colorToTurnTo = new Color (1f, 1f, 1f, alpha);
        textMesh.color= colorToTurnTo;
    }

    public bool isDoneDisplaying() {
        return alpha <= 0;
    }
}
