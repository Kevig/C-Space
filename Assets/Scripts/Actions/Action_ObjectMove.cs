using UnityEngine;

public class Action_ObjectMove : Action, IMove
{
	public PositionControl positionControl { get; set; }

	public Vector3 position {
		get => this.positionControl.targetVector;
		set => this.positionControl.targetVector = value;
	}

	public Action_ObjectMove(PositionControl control) {
		this.positionControl = control;
		this.EventListeners();
	}

	public virtual void EventListeners() {}

}
