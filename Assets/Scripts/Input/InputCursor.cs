using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCursor : MonoBehaviour {
  
	private static Vector3 _axes;
	public static Vector3 axes {
		get => _axes;
		set => _axes = value;
	}

	private static CursorLockMode _lockState;
	public static bool lockState {
		get => (_lockState == CursorLockMode.Locked);
		set {
			if(value) { _lockState = CursorLockMode.Locked; }
			else { _lockState = CursorLockMode.None; }
			Cursor.lockState = _lockState;
		}
	}

	public static Vector3 GetBaseAxes() {
		return new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
	}

	public static Vector3 GetReverseBaseAxes() {
		return new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
	}

	public static Vector3 GetAxes(RotationTarget target) {
		if(target == RotationTarget.Self) {
			return new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		} else if (target == RotationTarget.Pivot ) {
			return new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		} else { return Vector3.zero; }
	}

}
