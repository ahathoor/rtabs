var menuStyle: GUIStyle;
var target : Transform; //checks if the player is visible and nothing is blocking the view
var loop = true;	
	function Start () {
		
		while(loop){
		CanSeePlayer();
		yield WaitForSeconds(0.25);
		}
		yield WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel);
	}
	function CanSeePlayer(){
		var viewPos : Vector3 = GameObject.FindGameObjectWithTag("activeCam").GetComponent(Camera).WorldToViewportPoint (target.position);
		var player = GameObject.FindGameObjectWithTag("Player");
		var here = GameObject.FindGameObjectWithTag("activeCam").transform.position;
		var pos = GameObject.FindGameObjectWithTag("Player").transform.position;
		// do a Linecast:
      	var hit: RaycastHit;
		if(checkViewPos(viewPos)&& Physics.Linecast(here, pos, hit) && hit.transform == player.transform)
			loop=false;
	}
	
	function checkViewPos(viewPos : Vector3){
	if(viewPos.x>0 && viewPos.y>0 && viewPos.x<1 && viewPos.y<1 && viewPos.z>0){
		return true;
	}
	else{
		return false;
	}
}
	function OnGUI(){
		if(!loop){
			GUI.Label(Rect(Screen.width/2-200,Screen.height/2-100,1000,50),"Camera spotted you!", menuStyle);
		}
	
	}