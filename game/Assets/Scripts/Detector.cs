using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour
{

	public GUIText main_gui_text;
	private GameObject player;
	
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		if(player.rigidbody == null) {
			Debug.LogWarning("Wtf missä");
		}
		if(main_gui_text == null) {
			main_gui_text = (GUIText) GameObject.FindObjectOfType(typeof(GUIText));
		}
		main_gui_text.text = "";
	}
	
	void Update ()
	{
		if (CanSeePlayer ()) {
			main_gui_text.text = "Player Seen!";
			if(player.rigidbody.velocity.magnitude > 0.1f)
			{
				main_gui_text.text = "Player seen AND moving";
			}
		} else {
			main_gui_text.text = "";
		}
	}
	
	//	Checks if the active camera sees the player. If the player is behind another object the player is not seen.
	//	TODO:	Only detects if the center of the player object is visible. Needs to be changed to the whole player collider.
	//			player.collider.bounds.Contains (hit.transform.position) doesn't seem to be doing the trick :(
	bool CanSeePlayer ()
	{
		Vector3 viewPos = CameraManger.getActiveCamera().WorldToViewportPoint(player.transform.position);
		Vector3 here = CameraManger.getActiveCamera().transform.position;
		Vector3 pos = player.transform.position;
		RaycastHit hit;
		
		bool linecastHit = Physics.Linecast (here, pos, out hit);
		if(linecastHit && checkViewPos(viewPos) && player.collider.bounds.Contains (hit.transform.position))	{
			return true;
		}
		return false;
	}
	
	//	Checks if player is within the given view.
	bool checkViewPos (Vector3 viewPos)
	{
		if (viewPos.x > 0 && viewPos.y > 0 && viewPos.x < 1 && viewPos.y < 1 && viewPos.z > 0) {
			return true;
		} else {
			return false;
		}
	}
	
//	IEnumerator WaitAndLoadLevel (float wait)
	void WaitAndLoadLevel (float wait)
	{
		//yield return new WaitForSeconds(wait);
//		Application.LoadLevel (Application.loadedLevel);
	}
}