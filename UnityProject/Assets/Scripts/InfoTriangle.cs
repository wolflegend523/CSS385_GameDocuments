using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTriangle : MonoBehaviour
{
    [SerializeField] Color availableColor;
    [SerializeField] Color activeColor;
    [SerializeField] Color exhaustedColor;
    [SerializeField] Color enemyColor;

    [SerializeField] SpriteRenderer spriteRenderer;


    public void SetAvailable()
    {
        spriteRenderer.color = availableColor;
    }

    public void SetActive()
    {
        spriteRenderer.color = activeColor;
    }

    public void SetExhausted()
    {
        spriteRenderer.color = exhaustedColor;
    }

    public void SetEnemy()
    {
        spriteRenderer.color = enemyColor;
    }

    public void SetInvisible()
    {
        Color invisible = Color.white;
        invisible.a = 0;
        spriteRenderer.color = invisible; 
    }
}
