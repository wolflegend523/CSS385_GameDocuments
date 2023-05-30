using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] TutorialBox[] tutorialBoxes;
    private int boxPointer;

    // Start is called before the first frame update
    void Start()
    {
        hideAll();
        boxPointer = 0;
        tutorialBoxes[boxPointer].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showNext() {
        tutorialBoxes[boxPointer].gameObject.SetActive(false);
        boxPointer++;
        tutorialBoxes[boxPointer].gameObject.SetActive(true);
    }


    public void showPrevious() {
        tutorialBoxes[boxPointer].gameObject.SetActive(false);
        boxPointer--;
        tutorialBoxes[boxPointer].gameObject.SetActive(true);
    }

    public void hideAll() {
        foreach (TutorialBox box in tutorialBoxes)
        {
            box.gameObject.SetActive(false);
        }
    }

    public void changeCurrentBoxVisibility() {
        tutorialBoxes[boxPointer].gameObject.SetActive(!tutorialBoxes[boxPointer].isActiveAndEnabled);
    }
}
