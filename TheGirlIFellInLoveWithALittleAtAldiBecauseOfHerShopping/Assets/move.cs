using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	private Plane hitDetectPlane;
	private bool isMoving = false;
	private GameObject movingObject;

	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {
		int layerMask = 1 << 0;  // general

		if (Input.GetMouseButton(0)) {
			if (!isMoving) {
				RaycastHit hit;

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && (hit.rigidbody != null) && (hit.rigidbody.gameObject.tag == "Item")) {
					// move plane to initial hit position
					hitDetectPlane = new Plane(Vector3.left, hit.rigidbody.transform.position);
					movingObject = hit.rigidbody.gameObject;
					isMoving = true;
				}
			} else {
				//Debug.Log ("ismoving");
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float rayDistance;
				if (hitDetectPlane.Raycast(ray, out rayDistance))
					movingObject.transform.position = ray.GetPoint(rayDistance);
			}


			
			
			
		} else {
			isMoving = false;
		}
	}
}
