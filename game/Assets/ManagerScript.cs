using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour {
	
	public GameObject playerPrefab;
	public Transform startMarker;

	// Use this for initialization
	void Start () {
		Vector3 startPos = startMarker.position;
		GameObject p = (GameObject) Instantiate(playerPrefab, startPos, Quaternion.identity);
		p.tag = "Player";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}