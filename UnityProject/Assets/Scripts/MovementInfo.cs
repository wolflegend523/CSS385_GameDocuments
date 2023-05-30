using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementInfo : MonoBehaviour
{

    [SerializeField] Color altColor;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] TextMeshProUGUI costText;
    //[SerializeField] GameObject arrow;
    public void UpdateDisplay(PathfindNode node)
    {
        transform.position = node.position;
        costText.text = node.cost + "";

        int positionSum = (int) Mathf.Abs(transform.position.x + transform.position.y);
        if (positionSum % 2 == 1)
        {
            spriteRenderer.color = altColor;
        }

        if (node.previous == null)
        {
            //arrow.SetActive(false);
            return;
        }

        //arrow.transform.right = node.previous.position - node.position;

    }

}
