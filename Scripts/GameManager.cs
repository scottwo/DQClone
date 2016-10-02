using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public int xSize;
	public int zSize;
	public PlayerManager player;

	private List<GameObject> grid;

	// Use this for initialization
	void Start () {
		GenerateGrid ();
		AddPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void GenerateGrid() {
		grid = new List<GameObject> ();
		for (int i = 0; i < xSize; i++) {
			for (int j = 0; j < zSize; j++) {
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.parent = gameObject.transform;
				cube.transform.position = new Vector3 (i + 0.5f, 0.05f, j + 0.5f);
				cube.transform.localScale = new Vector3 (1.0f, 0.1f, 1.0f);
				grid.Add (cube);
			}
		}
	}

	void AddPlayer() {
		Instantiate(
			player, 
			new Vector3(
				grid[0].transform.position.x, 
				0.1f, 
				grid[0].transform.position.z
			), 
			Quaternion.identity
		);
	}
}
