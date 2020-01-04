using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class StageManager : MonoBehaviour
{
  public GameObject Player;

  public AudioSource audioSrc;
  public float audioDistance;

  public Stage[] stageList;
  public int nowStageNo = -1;

  [ReadOnly] public Stage nowStage;
  [ReadOnly] public int nowStageStep;
  [ReadOnly] public DIRECTION nowStageCorrectDirection;




  public IEnumerator goNextStage()
  {
    if (nowStageNo > -1)
    {
      Stage prevStage = stageList[nowStageNo];
      setCorrectCubes(prevStage.cubes, false);
    }

    nowStageNo++;
    nowStage = stageList[nowStageNo];
    nowStageStep = nowStage.cubes.Length;
    nowStageCorrectDirection = nowStage.correctDirection;
    setCorrectCubes(nowStage.cubes, true);

    Player.GetComponent<Rotate>().rotate(nowStage.turnAngle);
    yield return new WaitForSecondsRealtime(3);

    setAudioDirection(nowStageCorrectDirection);
    EventManager.GetInstance.TriggerEvent(EVENT.END_GO_NEXT_STAGE);
  }

  private void setCorrectCubes(GameObject[] cubes, bool isCorrectCube)
  {
    foreach (GameObject cube in cubes)
    {
      cube.GetComponent<TouchCube>().isCorrectCube = isCorrectCube;
    }

  }

  private void setAudioDirection(DIRECTION direction)
  {
    switch (direction)
    {
      case DIRECTION.LEFT:
        audioSrc.transform.localPosition = new Vector3(-1*audioDistance, 0, 0);
        break;
      case DIRECTION.RIGHT:
        audioSrc.transform.localPosition = new Vector3(audioDistance, 0, 0);
        break;
      case DIRECTION.FRONT:
        audioSrc.transform.localPosition = new Vector3(0, 0, audioDistance);
        break;
    }

  }



}
