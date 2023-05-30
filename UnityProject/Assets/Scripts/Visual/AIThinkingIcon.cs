using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIThinkingIcon : MonoBehaviour
{

    [SerializeField] GameObject icon;

    Vector3 startRotation;
    [SerializeField] Vector3 targetRotation;


    [SerializeField] float delayTime;

    float startTime;

    bool active;
    public void StartIcon()
    {
        active = true;
        icon.SetActive(true);
        icon.transform.localRotation = Quaternion.Euler(startRotation);
        startTime = Time.time;
    }

    public bool IsActive()
    {
        return active;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            float factor = (Time.time - startTime) / delayTime;
            icon.transform.localRotation = Quaternion.Euler(Vector3.Lerp(startRotation, targetRotation, factor));

            if (factor >= 1)
            {
                EndIcon();
            }

        }
    }
    void EndIcon()
    {
        active = false;
        icon.SetActive(false);
    }

    private void Start()
    {
        EndIcon();
    }

}
