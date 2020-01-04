using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCube : MonoBehaviour {
	public bool collisionEnabled = false;
	public bool isCorrectCube = false;

	public Material correctMaterial;

	public float collapseHeight;
	private bool isCollapsing;
	private Vector3 collapsePosition;

	private void OnCollisionEnter(Collision other) {
		if( isCorrectCube ) {
			Debug.Log("correct!"+gameObject.name);
			GetComponent<Renderer>().material = correctMaterial;
			collapsePosition = transform.position - new Vector3(0, collapseHeight, 0);
			isCollapsing = true;
		}
		else {
			Debug.Log("wrong!"+gameObject.name);
		}
	}

	private void Update() {
		if( isCollapsing ) {
			transform.position = Vector3.Lerp(transform.position, collapsePosition, Time.deltaTime);
			if( transform.position.y - collapsePosition.y < 0.001 ) {
				isCollapsing = false;
			}
		}
	}
}
