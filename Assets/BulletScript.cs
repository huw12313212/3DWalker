using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float AttackValue;
	public float AliveTime;

	// Use this for initialization
	void Start () 
	{

	}

	void Begin()
	{
		Invoke ("KillMyself",AliveTime);
		rigidbody.velocity = Velocity;
	}

	public Vector3 Velocity;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.T)) 
		{
			Begin();
		}
	
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.layer == LayerMask.NameToLayer ("Monster")) 
		{
//			MonsterScript monster = other.gameObject.GetComponent<MonsterScript>();	
			//monster.Hurt(AttackValue);
		}

	}


	void KillMyself()
	{
		GameObject.Destroy(this.gameObject);
	}
}
