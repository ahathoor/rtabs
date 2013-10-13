var menuStyle: GUIStyle;
function OnGUI () {
	GUI.Label(Rect(Screen.width/2-150,Screen.height/2-200,1000,50),"You made it!", menuStyle);
	
	
	if (GUI.Button (Rect (Screen.width/2-75,Screen.height/2-125,125,75), "Go Again'")) {
		Application.LoadLevel ("Level1");
	}
	if (GUI.Button (Rect (Screen.width/2-75,Screen.height/2-50,125,75), "Had enuf'")) {
		Application.Quit();
	}
}