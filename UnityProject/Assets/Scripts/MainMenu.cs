using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null)
            {
                return;
            }

            if (hit.collider.gameObject.tag == "startGame") {
                    SceneManager.LoadScene("first map");
            }

            if (hit.collider.gameObject.tag == "reset") {
                    SceneManager.LoadScene("titleScreen");
            }


        }
    }
}
