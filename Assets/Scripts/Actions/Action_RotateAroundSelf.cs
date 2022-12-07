public class Action_RotateAroundSelf : Action_CameraRotate, IAction {

	public Action_RotateAroundSelf(RotationControl rotationControl) : 
	base(rotationControl) { }

	public override void EventListeners() {
		CameraRotate.Self.Up_ON += this.UpOn;
		CameraRotate.Self.Up_OFF += this.XOff;
		CameraRotate.Self.Down_ON += this.DownOn;
		CameraRotate.Self.Down_OFF += this.XOff;
		CameraRotate.Self.Left_ON += this.LeftOn;
		CameraRotate.Self.Left_OFF += this.YOff;
		CameraRotate.Self.Right_ON += this.RightOn;
		CameraRotate.Self.Right_OFF += this.YOff;
		CameraRotate.Self.Free_ON += this.FreeOn;
		CameraRotate.Self.Free_OFF += this.FreeOff;
	}
	protected override void FreeOn() {
		this.UpdateRotation(RotationTarget.Self);
		base.FreeOn();
	}
}
