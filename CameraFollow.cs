using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player; // игрок
	public Vector3 offset; // растояние между камерой и игроком
	public float smoothSpeed; // плавное движение камеры
	float moveUp;
 
	void Awake ()
	{
		transform.position = player.transform.position + offset;
		moveUp = player.transform.position.y;
	}
 
	void LateUpdate()
	{
	Vector3 moveCamera = new Vector3 (player.transform.position.x, moveUp);
	transform.position = Vector3.Lerp (transform.position, moveCamera + offset, smoothSpeed * Time.deltaTime);
	}
}
