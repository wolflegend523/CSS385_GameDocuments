using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitNumber : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float time;

    float startTime;
    public void SetNumber(int number)
    {
        text.text = "" + number;
        startTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > time)
        {
            GameObject.Destroy(gameObject);
        }

    }
}
