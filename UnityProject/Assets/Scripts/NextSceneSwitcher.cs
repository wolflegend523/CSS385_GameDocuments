using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneSwitcher : MonoBehaviour
{

    public static string nextScene;

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);        
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
