using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Ground")
		{
			gameObject.transform.position = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(15, 25));
		}

		if(other.gameObject.tag == "Player")
		{
			GameObject[] kek = GameObject.FindGameObjectsWithTag("Box");
			foreach (GameObject item in kek)
			{
				item.transform.position = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(15, 20));
				item.SetActive(false);
			} 
		}
	}
}
