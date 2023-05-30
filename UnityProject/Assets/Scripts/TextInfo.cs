using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;

    public void UpdateText(string text)
    {
        textMesh.text = text;

    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
