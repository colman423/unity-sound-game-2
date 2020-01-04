
using UnityEngine;

public class RockDown : MonoBehaviour {
    public Vector3 StartPoint;
    public Vector3 EndPoint;
    public float speed;
    float nowValue = 0;

    private void Awake() {
        transform.localPosition = StartPoint;
        this.enabled = false;
    }

    private void FixedUpdate() {
        nowValue += speed;
        transform.localPosition = (1-nowValue)*StartPoint + nowValue * EndPoint;

        if( nowValue>=1 ) {
            this.enabled = false;
            EventManager.GetInstance.TriggerEvent(EVENT.FINAL_TEMPLE_UP);
        }

    }

}