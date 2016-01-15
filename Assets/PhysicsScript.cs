using UnityEngine;
using System.Collections;

public class PhysicsScript : MonoBehaviour {
	void OnCollisionEnter(Collision collision){
		Rigidbody rb = GetComponent<Rigidbody> ();
		if (collision.gameObject.name == "Cylinder") {
			rb.AddForce (0, 3, 0);
			rb.AddTorque (1, 1, 1);
		}
	}
	void OnCollisionStay(Collision collision){
		Rigidbody rb = GetComponent<Rigidbody> ();
		if (collision.gameObject.name == "Cylinder") {
			Debug.Log ("Contact");
			rb.AddForce (0, 3, 0);
			rb.AddTorque(1,1,1);
		}
	}
}
