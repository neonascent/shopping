using UnityEngine;
using System.Collections;

public class beltSwitch : MonoBehaviour {
	public int items;
	public GameObject music;
	public AudioSource ambientSounds;
	public AudioClip scan;

	public GameObject[] itemArray;
	public ConveyorBelt belt; 
	public float scanTime = 1f;
	private float conveyorSpeed = 0;
	private float stopTime;


	void OnTriggerEnter(Collider c) {
		if (belt.speed > 0) 
		conveyorSpeed = belt.speed;
		stopTime = Time.time;

	}

	void OnTriggerStay(Collider c) {
		//if (c.tag == "Item") 
			belt.speed = 0;
		if ((Time.time - stopTime) > scanTime) {
			removeItem(c.gameObject);
		}
	}

	void OnTriggerExit(Collider c) {
		belt.speed = conveyorSpeed;
	}

	void removeItem(GameObject g) {
		Destroy(g);
		((AudioSource)GetComponent<AudioSource> ()).Play ();
		items --;
		if (items == 0) {
			music.GetComponent<AudioHighPassFilter>().enabled = false;
			music.GetComponent<AudioReverbFilter>().enabled = false;

			ambientSounds.enabled = false;
		}

		for (int i = 0; i < itemArray.Length; i++) {
			itemArray[i].rigidbody.WakeUp();
		}

		belt.speed = conveyorSpeed;
	}

}
