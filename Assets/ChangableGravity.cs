using UnityEngine;
using System.Collections;

public class ChangableGravity : MonoBehaviour {


	public Vector3 currentGravity = new Vector3(0,-9.81f,0);
	

	// Use this for initialization
	void Start () {
		rigidbody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity += currentGravity*Time.deltaTime;
		rigidbody.sleepVelocity = 0.001f;
	}
}
