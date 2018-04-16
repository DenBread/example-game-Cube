using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour {

	public GameObject[] box;
	public float time = 1f;
	[SerializeField]
	private float timeFix;


	void FixedUpdate() {
		CreatCube();
	}

	void CreatCube()
	{
		time -= Time.deltaTime;
		if(time < 0)
		{
			for (int i = 0; i < box.Length; i++)
			{
				box[i].SetActive(true);
			}
		}
	}
}
