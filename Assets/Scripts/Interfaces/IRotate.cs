using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotate {

	RotationControl rotationControl { get; set; }
	Vector3 rotation { get; set; }
	
	void UpdateRotation(Axes axes, int direction);
}
