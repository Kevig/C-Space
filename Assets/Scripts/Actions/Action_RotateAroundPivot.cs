using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_RotateAroundPivot : Action_CameraRotate, IAction {

	public Action_RotateAroundPivot(RotationControl rotationControl) : 
	base(rotationControl) { }

	public override void EventListeners() {
		CameraRotate.Pivot.Up_ON += this.UpOn;
		CameraRotate.Pivot.Up_OFF += this.XOff;
		CameraRotate.Pivot.Down_ON += this.DownOn;
		CameraRotate.Pivot.Down_OFF += this.XOff;
		CameraRotate.Pivot.Left_ON += this.LeftOn;
		CameraRotate.Pivot.Left_OFF += this.YOff;
		CameraRotate.Pivot.Right_ON += this.RightOn;
		CameraRotate.Pivot.Right_OFF += this.YOff;
		CameraRotate.Pivot.Free_ON += this.FreeOn;
		CameraRotate.Pivot.Free_OFF += this.FreeOff;
	}
	protected override void FreeOn() {
		this.UpdateRotation(RotationTarget.Pivot);
		base.FreeOn();
	}
}
