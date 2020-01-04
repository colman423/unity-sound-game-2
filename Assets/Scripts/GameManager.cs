using System;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
  public CameraPath cameraPath;
  public GameObject player;
  public GameObject UIPanel;
  public GameObject StartPanel;

  public AudioSource audioSrc;
  public AudioClip[] soundFiles;
  private int soundFilesIndex = 0;

  private Move m_Move;

  private StageManager stageManager;
  private PenaltyManager penaltyManager;

  public int wrongStep = 1;
  private Vector3 positionBeforeMove;
  private Vector3 angleBeforeMove;

  private UnityAction goNextStageAction;
  private UnityAction endGoNextStageAction;
  private UnityAction goWrongPenaltyAction;
  private UnityAction endWrongPenaltyAction;




  private void Start()
  {
    m_Move = player.GetComponent<Move>();
    stageManager = GetComponent<StageManager>();
    penaltyManager = GetComponent<PenaltyManager>();


    goNextStageAction = new UnityAction(goNextStage);
    endGoNextStageAction = new UnityAction(endGoNextStage);
    goWrongPenaltyAction = new UnityAction(goWrongPanelty);
    endWrongPenaltyAction = new UnityAction(endWrongPanelty);

    EventManager.GetInstance.StartListening(EVENT.GO_NEXT_STAGE, goNextStageAction);
    EventManager.GetInstance.StartListening(EVENT.END_GO_NEXT_STAGE, endGoNextStageAction);
    
    EventManager.GetInstance.StartListening(EVENT.GO_WRONG_PENALTY, goWrongPenaltyAction);
    EventManager.GetInstance.StartListening(EVENT.END_WRONG_PENALTY, endWrongPenaltyAction);

    player.SetActive(false);

  }


  public void startGame() {
    StartPanel.SetActive(false);
    // Player.SetActive(false);
    cameraPath.enabled = true;
    EventManager.GetInstance.TriggerEvent(EVENT.GO_NEXT_STAGE);

  }


  public void goNextStage()
  {
    StartCoroutine(stageManager.goNextStage());
  }

  private void endGoNextStage() {
    UIPanel.SetActive(true);
    audioSrc.clip = soundFiles[(soundFilesIndex++)%2];
    audioSrc.enabled = true;
  }

  public void goWrongPanelty()
  {
    Debug.Log("goWrongPanelty 46");
    StartCoroutine(penaltyManager.getPenalty());
  }
  private void endWrongPanelty() {
    UIPanel.SetActive(true);
    audioSrc.enabled = true;
    player.transform.position = positionBeforeMove;
    player.transform.eulerAngles = angleBeforeMove;

  }



  public void pressLeft()
  {
    goDirection(DIRECTION.LEFT);
  }
  public void pressRight()
  {
    goDirection(DIRECTION.RIGHT);
  }
  public void pressFront()
  {
    goDirection(DIRECTION.FRONT);

  }
  private void goDirection(DIRECTION direction)
  {
    UIPanel.SetActive(false);
    audioSrc.enabled = false;
    positionBeforeMove = player.transform.position;
    angleBeforeMove = player.transform.eulerAngles;
    if (stageManager.nowStageCorrectDirection == direction)
    {
      m_Move.move(stageManager.nowStageCorrectDirection, stageManager.nowStageStep, EVENT.GO_NEXT_STAGE);
    }
    else
    {
      m_Move.move(direction, wrongStep, EVENT.GO_WRONG_PENALTY);


    }

  }
}
