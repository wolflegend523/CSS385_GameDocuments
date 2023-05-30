using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{

    Vector3 startPosition;
    [SerializeField] Vector3 deltaPosition;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = startPosition + deltaPosition * Mathf.Sin(speed*Time.time);
    }
}
