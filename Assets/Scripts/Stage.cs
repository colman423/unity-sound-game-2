using System;
using UnityEngine;

[System.Serializable]
public class Stage
{
  public DIRECTION correctDirection;
  public float turnAngle;
  [SerializeField] public GameObject[] cubes;
}
