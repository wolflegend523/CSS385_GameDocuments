using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverInfo : MonoBehaviour, IPointerEnterHandler,  IPointerExitHandler
{
    [SerializeField] GameObject hoverPrefab;

    [SerializeField] Vector3 hoverOffset;

    GameObject instance;

    Canvas parentCanvas;


    public void OnPointerEnter(PointerEventData eventData)
    {
        instance = GameObject.Instantiate(hoverPrefab, parentCanvas.transform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject.Destroy(instance);
        instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        parentCanvas = GetComponentInParent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instance != null)
        {
            instance.transform.position = Input.mousePosition + hoverOffset;
        }
    }
}
