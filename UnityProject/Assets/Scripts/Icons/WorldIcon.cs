using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldIcon : MonoBehaviour
{

    float startTime;

    [SerializeField] float activePeriod;

    SpriteRenderer spriteRenderer;
    Color startColor;
    // Start is called before the safirst frame update
    void Start()
    {
        startTime = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        float activeTime = Time.time - startTime;
        if (activeTime > activePeriod)
        {
            GameObject.Destroy(gameObject);
        } else
        {
            float transparency = Mathf.Sin(activeTime * Mathf.PI / activePeriod);
            startColor.a = transparency;
            spriteRenderer.color = startColor;
        }
    }
}
