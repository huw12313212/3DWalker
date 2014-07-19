using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class RotateControll : MonoBehaviour {

	public Transform mainCharacter;
	public Transform camera;

	public List<Vector3> ValidGravity;
	public ChangableGravity changableGravityScript;

	public float rotateTime;

	// Use this for initialization
	void Start () {
	//rigidbody.gr
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButtonDown (1)) 
		{
			ChangeGravityByCamera();
		}
	}

	void ChangeToGravity(Vector3 targetGravity)
	{
		Vector3 currentGravity = changableGravityScript.currentGravity;

		Quaternion newRotation;


		if(Vector3.Dot(targetGravity.normalized,currentGravity.normalized) <-0.8)
		{
			newRotation = getRotate180Quaternion ();

		}
		else
		{
			newRotation = getRotate90Quaternion ();
		}


		if(newRotation!=null)
		{
			HOTween.To (transform, 0.5f, new TweenParms ().Prop ("rotation", newRotation));
			changableGravityScript.currentGravity = targetGravity;
		}
	}

	Quaternion getRotate90Quaternion()
	{
		Quaternion init = transform.rotation;
		Vector3 direction = getGravityDirection(transform.forward);
		transform.LookAt(transform.position+direction,transform.up);
		transform.Rotate(-90,0,0,Space.Self);
		Quaternion newRotation = transform.rotation;
		transform.rotation = init;

		return newRotation;
	}

	
	Quaternion getRotate180Quaternion()
	{
		Quaternion init = transform.rotation;
		transform.Rotate(-180,0,0,Space.Self);
		Quaternion newRotation = transform.rotation;
		transform.rotation = init;
		
		return newRotation;
	}

	void ChangeGravityByCamera()
	{
		Vector3 facingDirection = camera.forward;
		Vector3 TargetGravity = getGravityDirection(facingDirection);
		
		Debug.Log("Gravity:"+TargetGravity);

		ChangeToGravity(TargetGravity);
	}

	public Vector3 getGravityDirection(Vector3 facingDirection)
	{
		Vector3 TargetGravity = ValidGravity[0];
		float max = 0;
		foreach(Vector3 candidateGravity in ValidGravity)
		{
			float dotValue = Vector3.Dot(candidateGravity,facingDirection);
			if(dotValue>max)
			{
				max = dotValue;
				TargetGravity = candidateGravity;
			}
		}

		return TargetGravity;

	}
}
