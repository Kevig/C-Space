using UnityEngine;

public class Action_CameraRotate : Action, IRotate {

	public RotationControl rotationControl { get; set; }

	public Vector3 rotation {
		get => this.rotationControl.targetVector;
		set => this.rotationControl.targetVector = value;
	}

	public Action_CameraRotate(RotationControl control) {
		this.rotationControl = control;
		this.EventListeners();
	}

	public virtual void EventListeners() { }
 
	protected void UpOn() { this.UpdateRotation(Axes.x, -1); }
	protected void XOff() { this.UpdateRotation(Axes.x, 0); }
	protected void DownOn() { this.UpdateRotation(Axes.x, 1); }
	protected void LeftOn() { this.UpdateRotation(Axes.y, -1); }
	protected void YOff() { this.UpdateRotation(Axes.y, 0); }
	protected void RightOn() { this.UpdateRotation(Axes.y, 1); }

  public void UpdateRotation(Axes axes, int direction) {
		Vector3 rotation = this.rotation;
		if(axes == Axes.y) { rotation.y = direction; }
		else { rotation.x = direction; }
		this.rotation = rotation;
	}

	public void UpdateRotation(RotationTarget target) {
		Vector3 rotation = InputCursor.GetReverseBaseAxes();
		if(target == RotationTarget.Self) { rotation.x = -rotation.x; }
		else if(target != RotationTarget.Pivot) { rotation = Vector3.zero; }
		this.rotation = rotation;
	}

	protected virtual void FreeOn() {
		InputCursor.lockState = true;
	}

	protected void FreeOff() {
		this.rotation = Vector3.zero;
		InputCursor.lockState = false;
	}

}
