using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundaries : MonoBehaviour
{
    [SerializeField] Vector3 TopLeft;
    [SerializeField] Vector3 BottomRight;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(TopLeft, 0.5f);
        Gizmos.DrawWireSphere(BottomRight, 0.5f);

        Gizmos.DrawLine(TopLeft, new Vector3(TopLeft.x, BottomRight.y));
        Gizmos.DrawLine(TopLeft, new Vector3(BottomRight.x, TopLeft.y));
        Gizmos.DrawLine(BottomRight, new Vector3(TopLeft.x, BottomRight.y));
        Gizmos.DrawLine(BottomRight, new Vector3(BottomRight.x, TopLeft.y));
    }
}
