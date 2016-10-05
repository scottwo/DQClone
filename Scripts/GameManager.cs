using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public PlayerManager player;

	private PlayerManager playerInstance;
	private GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find ("Main Camera (origin)");
		AddPlayer ();
	}
		
	void AddPlayer() {
		playerInstance = (PlayerManager) Instantiate(
			player, 
			new Vector3(
				0f, 
				0.333f, 
				0f
			), 
			Quaternion.identity
		);
		mainCamera.transform.position = new Vector3 (
			playerInstance.transform.position.x,
			playerInstance.transform.position.y,
			playerInstance.transform.position.z - 2f
		);
	}
}
