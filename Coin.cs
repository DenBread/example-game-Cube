using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public int coin;
	public TapToPlay times;
	private void Start() {
		gameObject.transform.position = new Vector3(Random.Range(-8f, 8f), 1.5f);
	}

	private void LateUpdate() {
		gameObject.transform.Rotate(0f,0f, 100 * Time.deltaTime);
	}

	private void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == "Player")
		{
			times.time += coin;
			gameObject.transform.position = new Vector3(Random.Range(-8f, 8f), 1.5f);
		}
	}

	
}
