//script swapping to random camera view

var current=1;
var numberOfCams;
function Start () {
	camSwap(1);
	var loop = true;
	var rnd=0;	
	/*while (loop){			//random cam swap
		yield WaitForSeconds(3);		
		while(rnd==current){
		rnd=Random.Range(1,numberOfCams+1);
		}
		Debug.Log("Random "+rnd);
		current=rnd;
		camSwap(rnd);
		
	}*/
	
	while(loop){
		yield WaitForSeconds(3);
		current++;
		if(current>numberOfCams){
			current=1;
		}
		var active = GameObject.FindGameObjectWithTag("activeCam");
		active.tag="cam";
		camSwap(current);
	}
}
 
function camSwap(currentCam : int){
 var cameras = GameObject.FindGameObjectsWithTag("cam");
 numberOfCams=0;
 for (var cams : GameObject in cameras){
  cams.GetComponent(Camera).enabled = false;
  numberOfCams++;
  
 }  
 Debug.Log("Number of cameras is "+numberOfCams);
 var oneToUse : String = "cam"+currentCam;
 gameObject.Find(oneToUse).GetComponent(Camera).enabled = true;
 gameObject.Find(oneToUse).tag="activeCam";
}
 
function OnGUI(){
    GUI.Label(Rect(0,0,Screen.width,Screen.height),"Camera "+current);
}

