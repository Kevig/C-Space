using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom
{
	public delegate void ZoomCamera();

	public static event ZoomCamera Zoom_In, Zoom_Out;

	public CameraZoom() { }

	public void Trigger(Direction direction)
	{
		try {
		if(direction == Direction.In) { Zoom_In(); }
		else if(direction == Direction.Out) { Zoom_Out(); }
		else {
			// InputState does not represent a zoom direction - DO NOTHING
		}
		} catch(System.NullReferenceException) {
			// No Action_CameraZoom scripts exist on any active gameobject
		}
	}

	public override string ToString(){
		return "Camera Zoom";
	}
}
