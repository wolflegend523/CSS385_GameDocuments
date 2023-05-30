using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{


    static IconManager instance;

    public static IconManager Get()
    {
        return instance;
    }

    [SerializeField] GameObject IconPrefab;

    void Awake()
    {
        instance = this;   
    }

    public void CreateIcon(Vector3 location, Sprite sprite)
    {
        GameObject icon = GameObject.Instantiate(IconPrefab);

        icon.transform.position = location;
        icon.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
