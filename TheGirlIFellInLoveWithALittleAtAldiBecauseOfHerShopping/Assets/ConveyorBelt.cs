using UnityEngine;
using System.Collections;

public class ConveyorBelt : MonoBehaviour {
	
	public float speed = 3.0f;
	public Material belt;

	void Update() {
		Vector2 offset = belt.mainTextureOffset;
		offset.y += (Time.deltaTime * speed) / (transform.localScale.x * 65);
		belt.mainTextureOffset  = offset;
	}


	void OnCollisionStay(Collision collision) {
		//if (collision.gameObject.tag != "Player")
		//	return;

		// Assign velocity based upon direction of conveyor belt
		// Ensure that conveyor mesh is facing towards its local Z-axis
		
		//float conveyorVelocity = speed * Time.deltaTime;

		Rigidbody other = collision.gameObject.rigidbody;


		other.rigidbody.MovePosition(other.transform.position + transform.forward * Time.deltaTime * speed);


		//if( other.rigidbody != null && speed != 0 )
		//	other.rigidbody.MovePosition( other.transform.position + Vector3.forward * Time.deltaTime * speed);

		//rigidbody.velocity = conveyorVelocity * transform.forward;
		//Rigidbody.AddForce(conveyorVelocity * transform.forward, ForceMode.VelocityChange)
	}

}