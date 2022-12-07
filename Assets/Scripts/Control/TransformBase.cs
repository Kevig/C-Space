using UnityEngine;

public class TransformBase : MonoBehaviour {
  
	[SerializeField]
	private ActionListener _actionType;
	public ActionListener actionType {
		get => this._actionType;
		set => this._actionType = value;
	}
	
	[SerializeField]
	private Action _eventListener;
	public Action eventListener {
		get => this._eventListener;
		set => this._eventListener = value;
	}

	[Space]
	[SerializeField]
	private float _step;
	public float step {
		get => this._step;
		set => this._step = value;
	}

	[SerializeField]
	private float _duration;
	public float duration {
		get => this._duration;
		set => this._duration = (value < 0f) ? 0f : value;
	}

	protected void initActionListener(dynamic control) {
		switch(this.actionType) {
			case ActionListener.Camera_Rotate_Pivot:
				this.eventListener = new Action_RotateAroundPivot(control);
			break;
			case ActionListener.Camera_Rotate_Self:
				this.eventListener = new Action_RotateAroundSelf(control);
			break;
			case ActionListener.Camera_Zoom:
				this.eventListener = new Action_CameraZoom(control);
			break;
			case ActionListener.Player_Move:
				this.eventListener = new Action_PlayerMove(control);
			break;
		}
	}
}
