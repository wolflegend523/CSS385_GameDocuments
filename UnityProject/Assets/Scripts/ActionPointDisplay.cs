using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPointDisplay : MonoBehaviour
{

    [SerializeField] GameObject actionPointPrefab;

    [SerializeField] Transform actionPointInitialPosition;

    [SerializeField] float deltaX;


    List<GameObject> currentPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    int lastMove;
    int lastAction;
    public void SetDisplay(int move, int action)
    {

        if (move == lastMove && action == lastAction)
        {
            return;
        }

        ClearDisplay();
        for (int i = 0; i < move; i++)
        {
            AddNewActionPoint(Color.green);
        }
        for (int i = 0; i < action; i++)
        {
            AddNewActionPoint(Color.red);
        }

        lastMove = move;
        lastAction = action;

    }

    public void ClearDisplay()
    {
        foreach (GameObject point in currentPoints)
        {
            GameObject.Destroy(point);
        }
        currentPoints.Clear();
    }

    public void AddNewActionPoint(Color c)
    {
        GameObject clone = GameObject.Instantiate(actionPointPrefab, actionPointInitialPosition);
        clone.transform.localPosition = new Vector3(deltaX * currentPoints.Count, 0, 0);

        clone.GetComponent<Image>().color = c;

        currentPoints.Add(clone);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
