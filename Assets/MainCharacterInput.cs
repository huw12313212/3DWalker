using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainCharacterInput : MonoBehaviour {

	public float MoveSpeed;
	public float JumpSpeed;
	public List<Collider> floor = new List<Collider>();
	public float MaxSpeed;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision collision) 
	{

		Debug.Log (collision.collider.gameObject.name+" :"+collision.contacts [0].normal);

		Vector3 normal = collision.contacts [0].normal;

		if (Vector3.Dot (normal, transform.up) > 0.8) 
		{
			floor.Add(collision.collider);
		}
	}




	void OnCollisionExit(Collision collisionInfo) 
	{
		floor.Remove(collisionInfo.collider);
	}



	// Update is called once per frame
	void Update () {
	


		if (Input.GetKey (KeyCode.W)) 
		{
			if(Vector3.Dot(rigidbody.velocity,transform.forward)<MaxSpeed)
			{
				rigidbody.velocity += transform.forward*MoveSpeed;
			}
		}

		
		if (Input.GetKey (KeyCode.S)) 
		{
			if(Vector3.Dot(rigidbody.velocity,-transform.forward)<MaxSpeed)
			{
				rigidbody.velocity += -transform.forward*MoveSpeed;
			}
		}


		if (Input.GetKeyDown (KeyCode.Space))
		{
			if(floor.Count>0)
			{
				rigidbody.velocity += transform.up*JumpSpeed;
			}
		}


		if (Input.GetKey (KeyCode.A)) 
		{
			if(Vector3.Dot(rigidbody.velocity,-transform.right)<MaxSpeed)
			{
				rigidbody.velocity += -transform.right*MoveSpeed;
			}
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			if(Vector3.Dot(rigidbody.velocity,transform.right)<MaxSpeed)
			{
				rigidbody.velocity += transform.right*MoveSpeed;
			}
		}



	}
}
