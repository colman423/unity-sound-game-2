using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public enum DIRECTION
{
  LEFT = 1,
  RIGHT = 2,
  FRONT = 3
};

public class Move : MonoBehaviour
{
  public float moveSpeed;
  public float jumpHeight;
  public float scale = 1;



  // private Vector3 toMove;
  public void move(DIRECTION direction, int times, EVENT callbackEvent)
  {
    Vector3 stepMove = new Vector3(0, 0, 0);
    if (angleEqual(transform.eulerAngles.y, 0))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(-1, 0, 0);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(1, 0, 0);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(0, 0, 1);
    }
    else if (angleEqual(transform.eulerAngles.y, 45))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(-1, 0, 1);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(1, 0, -1);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(1, 0, 1);
    }
    else if (angleEqual(transform.eulerAngles.y, 90))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(0, 0, 1);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(0, 0, -1);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(1, 0, 0);
    }
    else if (angleEqual(transform.eulerAngles.y, 135))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(1, 0, 1);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(-1, 0, -1);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(1, 0, -1);
    }
    else if (angleEqual(transform.eulerAngles.y, 180))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(1, 0, 0);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(-1, 0, 0);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(0, 0, -1);
    }
    else if (angleEqual(transform.eulerAngles.y, 225))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(1, 0, -1);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(-1, 0, 1);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(-1, 0, -1);
    }
    else if (angleEqual(transform.eulerAngles.y, 270))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(0, 0, -1);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(0, 0, 1);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(-1, 0, 0);
    }
    else if (angleEqual(transform.eulerAngles.y, 315))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(-1, 0, -1);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(1, 0, 1);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(-1, 0, 1);
    }
    else
    {
      Debug.Log("Move.move angleEqual ERRRR!!!");
    }
    StartCoroutine(moveStepByStep(stepMove, times, callbackEvent));
  }

  private IEnumerator moveStepByStep(Vector3 stepMove, int times, EVENT callbackEvent)
  {
    Vector3 originAngle = transform.eulerAngles;
    for (int i = 0; i < times; i++)
    {
      moveStep(stepMove, originAngle);
      yield return new WaitForSecondsRealtime(moveSpeed);
    }
    EventManager.GetInstance.TriggerEvent(callbackEvent);

  }

  private void moveStep(Vector3 stepMove, Vector3 originAngle)
  {
    transform.position += (stepMove + new Vector3(0, jumpHeight, 0)) * scale;
    transform.eulerAngles = originAngle;

  }


  private bool angleEqual(float a, float b)
  {
    float threshhold = 10f;
    a %= 360;
    b %= 360;
    return (
      (a - b) < threshhold && (a - b) > -1 * threshhold ||
      (a - 360 - b) < threshhold && (a - 360 - b) > -1 * threshhold ||
      (a + 360 - b) < threshhold && (a + 360 - b) > -1 * threshhold
    );
  }
}
