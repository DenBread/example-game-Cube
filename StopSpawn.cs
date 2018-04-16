using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSpawn : MonoBehaviour {
	
	public TapToPlay timeCheck;
	public GameObject box;
	public GameObject coin;

	public GameObject panalScore;
	public GameObject GameOver;



	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Box")
		{

			coin.SetActive(false);
			panalScore.SetActive(true);
			GameOver.SetActive(true);

			timeCheck.timeBool = false;

			box.SetActive(false);

			timeCheck.buttonGameOver.SetBool("BackAgan", false);
		}
	}
}
