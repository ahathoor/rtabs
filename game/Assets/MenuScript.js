function OnGUI () {
		
	if (GUI.Button (Rect (Screen.width/2-75,Screen.height/2-125,125,75), "Start sneakin'")) {
		Application.LoadLevel ("Level1");
	}
	if (GUI.Button (Rect (Screen.width/2-75,Screen.height/2-50,125,75), "Rage quit")) {
		Application.Quit();
	}
}