using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
	GameObject[] cubearray = new GameObject [30];
	Rigidbody[] cubebody = new Rigidbody [30];
	GameObject cyl;
	Rigidbody tornado;
	GameObject floor;
	public float speed = 10;
	Vector3 newPosition;
	int n, j, k;
	// Use this for initialization
	void Start () {
		PhysicsScript ps;
		j = -5;
		n = k = 0;
		floor = GameObject.CreatePrimitive (PrimitiveType.Quad);
		floor.transform.position = new Vector3 (0, -.01f, 0);
		floor.transform.localScale = new Vector3 (1000, 1000, 1);
		floor.transform.Rotate (90, 0, 0);
		for (n = 0; n < 30; n++) {
			cubearray [n] = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cubearray [n].transform.localScale = new Vector3 (2, 1, 1);
			cubearray [n].transform.position = new Vector3 (j, k+.5f, 13);
			cubebody [n] = cubearray [n].AddComponent<Rigidbody> ();	
			cubearray [n].AddComponent<PhysicsScript> ();
			cubebody [n].useGravity = true;
			cubebody [n].mass = 0.01f;
			k++;
			if (k > 4)
				k = 0;
			if (n % 5 == 0.0)
				j+=2;
			if (j > 5)
				j = -5;
		}
		cyl = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		cyl.transform.localScale = new Vector3 (6, 5, 6);
		newPosition = new Vector3 (0, 0, 0);
		cyl.transform.position = new Vector3 (0, 5, -8);
		tornado = cyl.AddComponent<Rigidbody> ();
		tornado.mass = 500000000;
	}
	// Update is called once per frame
	void Update () {
		cyl.transform.Translate ((newPosition.x)/ 150,
			0.0f, (newPosition.z)/ (150));
		Camera.main.transform.position = new Vector3 ((newPosition.x) / 500 + Camera.main.transform.position.x,
			Camera.main.transform.position.y, (newPosition.z) / 500 + Camera.main.transform.position.z);
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				newPosition = hit.point;
				Debug.Log (newPosition);
			}
		}
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel (0);
		}
	}
}
