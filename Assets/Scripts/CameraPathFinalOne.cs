
using UnityEngine;
using System.Collections;

public class CameraPathFinalOne : MonoBehaviour
{
    public float speed = 3f;
    public Transform pathParent;
    public GameObject nextBtnPanel;

    Transform targetPoint;
    int index;

    void OnDrawGizmos()
    {
        Vector3 from;
        Vector3 to;
        for (int a = 0; a < pathParent.childCount; a++)
        {
            from = pathParent.GetChild(a).position;
            to = pathParent.GetChild((a + 1) % pathParent.childCount).position;
            Gizmos.color = new Color(1, 0, 0);
            Gizmos.DrawLine(from, to);
        }
    }
    void Start()
    {
        index = 0;
        targetPoint = pathParent.GetChild(index);
        // transform.position = targetPoint.position;
        // Player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            index++;
            if (index >= pathParent.childCount)
            {
                this.enabled = false;
                nextBtnPanel.SetActive(true);

                // gameObject.GetComponent<CameraPathFinalTwo>().enabled = true;
                // Player.SetActive(true);
            }
            else
            {
                // index %= pathParent.childCount;
                targetPoint = pathParent.GetChild(index);
            }
        }
    }
}