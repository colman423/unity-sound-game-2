using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
  public GameObject footCube;

	private void OnCollisionEnter(Collision other) {
		footCube = other.gameObject;
	}
}
