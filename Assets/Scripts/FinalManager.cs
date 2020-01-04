using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class FinalManager : MonoBehaviour
{
    public GameObject Player;
    public RockDown rockDown;
    public TempleUp templeUp;
    public GameObject interActivePanel;
    public GameObject youWinPanel;
    public CameraFollow cameraFollow;
    public CameraPathFinalOne cameraPathFinalOne;
    public CameraPathFinalTwo cameraPathFinalTwo;
    private Move m_Move;

    private UnityAction goFinalAction;
    private UnityAction finalRockDownAction;
    private UnityAction finalTempleUpAction;
    private UnityAction finalAnimationAction;

    private void Start()
    {
        m_Move = Player.GetComponent<Move>();

        goFinalAction = new UnityAction(goFinal);
        finalRockDownAction = new UnityAction(finalRockDown);
        finalTempleUpAction = new UnityAction(finalTempleUp);
        finalAnimationAction = new UnityAction(finalAnimation);

        EventManager.GetInstance.StartListening(EVENT.GO_FINAL, goFinalAction);
        EventManager.GetInstance.StartListening(EVENT.FINAL_ROCK_DOWN, finalRockDownAction);
        EventManager.GetInstance.StartListening(EVENT.FINAL_TEMPLE_UP, finalTempleUpAction);
        EventManager.GetInstance.StartListening(EVENT.FINAL_ANIMATION, finalAnimationAction);
    }

    public void goFinal()
    {
        Debug.Log("GO FINAL START!!!");
        m_Move.move(DIRECTION.FRONT, 7, EVENT.FINAL_ROCK_DOWN);

    }

    private void finalRockDown()
    {
        Debug.Log("finalRockDown!!!");
        rockDown.enabled = true;
        // EventManager.GetInstance.TriggerEvent(EVENT.FINAL_TEMPLE_UP);

    }
    private void finalTempleUp()
    {
        templeUp.enabled = true;
        Debug.Log("finalTempleUp!!!");

    }

    private void finalAnimation()
    {
        Debug.Log("finalAnimation!!!");
        interActivePanel.SetActive(false);
        youWinPanel.SetActive(true);
        cameraFollow.enabled = false;
        cameraPathFinalOne.enabled = true;

    }

    public void goCameraPathTwo() {
      cameraPathFinalTwo.enabled = true;
    }


}
