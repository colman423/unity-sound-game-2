
using UnityEngine;
using System.Collections;

public class CameraPath : MonoBehaviour
{
    public GameObject Player;
    public float speed = 3f;
    public Transform pathParent;
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
        transform.position = targetPoint.position;
        // Player.SetActive(false);
        // this.enabled = false;
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
                gameObject.GetComponent<CameraFollow>().enabled = true;
                Player.SetActive(true);
            }
            else
            {
                // index %= pathParent.childCount;
                targetPoint = pathParent.GetChild(index);
            }
        }
    }
}