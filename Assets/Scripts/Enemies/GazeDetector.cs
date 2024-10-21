using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeDetector : MonoBehaviour
{
    // Variables publicas
    public SkinnedMeshRenderer meshRenderer;
    public Transform point1, point2, point3;
    public bool IsRendered()
    {
        if (meshRenderer.isVisible)
        {
            RaycastHit hit1, hit2, hit3;
            Physics.Raycast(point1.transform.position, (Player.Instance.transform.position - new Vector3(0f, -1f, 0f)) - point1.transform.position, out hit1, 500f);
            Physics.Raycast(point2.transform.position, (Player.Instance.transform.position - new Vector3(0f, -1f, 0f)) - point2.transform.position, out hit2, 500f);
            Physics.Raycast(point3.transform.position, (Player.Instance.transform.position - new Vector3(0f, -1f, 0f)) - point3.transform.position, out hit3, 500f);
            if (!hit1.transform.gameObject.CompareTag("Player") && !hit2.transform.gameObject.CompareTag("Player") && !hit3.transform.gameObject.CompareTag("Player"))
            {
                return false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
