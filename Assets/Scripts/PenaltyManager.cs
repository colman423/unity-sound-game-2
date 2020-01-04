using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PenaltyManager : MonoBehaviour
{
  public GameObject Player;
  public float penaltyTime = 1;

  public IEnumerator getPenalty()
  {
    // Player.transform.position = Player.transform.position + new Vector3(0, 20, 0);
    // Player.transform.eulerAngles = Player.transform.eulerAngles + new Vector3(0, 20, 0);
    GameObject footCube = Player.GetComponent<PlayerManager>().footCube;
    footCube.SetActive(false);

    yield return new WaitForSecondsRealtime(penaltyTime);
    
    footCube.SetActive(true);
    EventManager.GetInstance.TriggerEvent(EVENT.END_WRONG_PENALTY);

  }
  // public void 

}
