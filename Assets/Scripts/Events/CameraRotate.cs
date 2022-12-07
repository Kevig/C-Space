using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : IEvent
{
	
	private dynamic _control;
	public dynamic control {
		get => this._control;
		set => this._control = value;
	}

	private RotationTarget _rotationTarget;
	public RotationTarget rotationTarget {
		get => this._rotationTarget;
		set => this._rotationTarget = value;
	}

	public class Self {
		
		public delegate void RotateSelf();

		public static event RotateSelf
			Up_ON, Up_OFF,
			Down_ON, Down_OFF,
			Left_ON, Left_OFF,
			Right_ON, Right_OFF,
			Free_ON, Free_OFF;

		private CameraRotate _owner;
		public CameraRotate owner {
			get => this._owner;
			set => this._owner = value;
		}

		public Self(CameraRotate cameraRotate) { this.owner = cameraRotate; }

		public void Up(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Up_ON(); }
			else { Up_OFF(); }
		}

		public void Down(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Down_ON(); }
			else { Down_OFF(); }
		}

		public void Left(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Left_ON(); }
			else { Left_OFF(); }
		}

		public void Right(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Right_ON(); }
			else { Right_OFF(); }
		}

		public void Free(InputState state) {
			if(state == InputState.Hold) { Free_ON(); }
			else { Free_OFF(); }
		}

		public override string ToString() { return "Camera Rotate Around Self"; }
	}

	public class Pivot {

		public delegate void RotatePivot();

		public static event RotatePivot
			Up_ON, Up_OFF,
			Down_ON, Down_OFF,
			Left_ON, Left_OFF,
			Right_ON, Right_OFF,
			Free_ON, Free_OFF;

		private CameraRotate _owner;
		public CameraRotate owner {
			get => this._owner;
			set => this._owner = value;
		}

		public Pivot(CameraRotate cameraRotate) { this.owner = cameraRotate; }

		public void Up(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Up_ON(); }
			else { Up_OFF(); }
		}

		public void Down(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Down_ON(); }
			else { Down_OFF(); }
		}

		public void Left(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Left_ON(); }
			else { Left_OFF(); }
		}

		public void Right(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Right_ON(); }
			else { Right_OFF(); }
		}

		public void Free(InputState state) {
			if(state == InputState.Hold) { Free_ON(); }
			else { Free_OFF(); }
		}

		public override string ToString() { return "Camera Rotate Around Pivot"; }
	}

	public CameraRotate(RotationTarget rotationTarget) {
		switch(rotationTarget) {
			case RotationTarget.Self: this.control = new CameraRotate.Self(this); break;
			case RotationTarget.Pivot: this.control = new CameraRotate.Pivot(this); break;
		}
	}

	public void Trigger(InputItem inputItem) {
		this.TriggerEvent(inputItem.keyCode, inputItem.state);
	}

	public void TriggerEvent(KeyCode direction, InputState state) {
		switch(direction) {
			case KeyCode.UpArrow: this.control.Up(state); break;
			case KeyCode.DownArrow: this.control.Down(state); break;
			case KeyCode.LeftArrow: this.control.Left(state); break;
			case KeyCode.RightArrow: this.control.Right(state); break;
			case KeyCode.Mouse0: this.control.Free(state); break;
		}
	}

	public override string ToString() { return this.control.ToString(); }

}
