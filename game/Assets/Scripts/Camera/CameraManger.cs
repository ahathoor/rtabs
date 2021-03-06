﻿using UnityEngine;
using System.Collections;
using System;																							//	Required for array sorting

public class CameraManger : MonoBehaviour
{	
	
	Camera[] cameras;
	AudioListener listener;
	Camera follow_cam;
	static Camera active_cam;
	
	// Use this for initialization
	void Start ()
	{
		cameras = FindObjectsOfType(typeof(Camera)) as Camera[];
		Debug.Log("Found " + cameras.Length + " cameras");
		
		//	Sort cameras into depth order starting from the lowest
		Array.Sort(cameras, delegate(Camera cam1, Camera cam2)	{
			return cam1.depth.CompareTo(cam2.depth);
			});
		
		//	Enable first camera and its AudioListener
		cameras[0].enabled = true;
		listener = cameras[0].GetComponent(typeof(AudioListener)) as AudioListener;										
		listener.enabled = true;
		active_cam = cameras[0];
		
		//	Disable all other cameras and their AudioListeners
		for(int i = 1; i < cameras.Length; i++)	{
			listener = cameras[i].GetComponent(typeof(AudioListener)) as AudioListener;
			listener.enabled = false;
			cameras[i].enabled = false;
		}
		
		//	Assign follow_cam and remove it from the list of cycling cameras
		//	IMPORTANT NOTE: The "Following Camera" must have the highest "Depth" value. Set it to 100 in the editor to be safe.
		follow_cam = cameras[cameras.Length-1];
		Array.Resize(ref cameras, (cameras.Length-1));
		
		StartCoroutine (WaitAndCycle (4));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (WinCondition.WinOrNot == true){
			SwitchCameras(active_cam, follow_cam);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			CycleCameras ();
		}
	}

	IEnumerator WaitAndCycle (float lag)
	{
		while (true) {
			yield return new WaitForSeconds(lag);
			CycleCameras();
		}
	}
	
	void CycleCameras ()
	{	
		//	Finds active camera from cameras[] and switches to the next one.
		for(int i = 0; i < cameras.Length; i++)	{
			if (cameras[i].enabled == true)	{
				if(i == cameras.Length-1)	{
					SwitchCameras(cameras[i], cameras[0]);
					return;
				}
				else {
					SwitchCameras (cameras[i], cameras[i+1]);
					return;
				}
			}
		}
	}
	
	void SwitchCameras (Camera from_camera, Camera to_camera)
	{
		listener = from_camera.GetComponent(typeof(AudioListener)) as AudioListener;
		listener.enabled = false;
		from_camera.enabled = false;
		
		listener = to_camera.GetComponent(typeof(AudioListener)) as AudioListener;
		listener.enabled = true;
		to_camera.enabled = true;
		
		active_cam = to_camera;
	}
	
	public static Camera getActiveCamera()
	{
		return active_cam;
	}
}
