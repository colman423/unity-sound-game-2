using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Rotate : MonoBehaviour
{
  private float targetAngleY;
  private bool isRotating = false;
  public CameraFollow cameraFollow;

  public void rotate(float angle)
  {
    Debug.Log("Rotate rotate");
    targetAngleY = transform.eulerAngles.y + angle;
    isRotating = true;
    cameraFollow.followAng = true;
  }

  public void rotateTo(float angle)
  {
    targetAngleY = angle;
    isRotating = true;
    cameraFollow.followAng = true;
  }

  private void Update()
  {
    if (isRotating)
    {
      Vector3 targetEularAngles = new Vector3(transform.eulerAngles.x, targetAngleY, transform.eulerAngles.z);
      transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetEularAngles, Time.deltaTime);

      float gap = transform.eulerAngles.y - targetEularAngles.y;
      if (gap < 0.001 && gap > -0.001)
      {
        isRotating = false;
        cameraFollow.followAng = false;
      }
    }
  }
}
