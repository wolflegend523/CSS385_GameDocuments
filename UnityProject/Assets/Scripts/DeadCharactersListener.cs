using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DeadCharactersListener : MonoBehaviour
{

    [SerializeField] Controller controller;

    bool deadEventFired = false;
    [SerializeField] UnityEvent deadEvent;


    float startTime;

    [SerializeField] float delay;

    bool active;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            if (controller.AreAllCharactersDead())
            {
                startTime = Time.time;
                active = true;
            }
        } else
        {
            if (!deadEventFired)
            {
                if (Time.time - startTime > delay)
                {
                    deadEventFired = true;

                    deadEvent.Invoke();

                }
            }
        }



    }


    public void CacheNextScene(string nextScene)
    {
        NextSceneSwitcher.nextScene = nextScene;
    }

    public void SwitchScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
