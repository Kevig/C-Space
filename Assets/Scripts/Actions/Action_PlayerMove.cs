using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_PlayerMove : Action_ObjectMove, IAction {

	public Action_PlayerMove(PositionControl positionControl) :
	base(positionControl) { }

	public override void EventListeners() {
		CharacterMove.Player.Forward_On += this.Forward;
		CharacterMove.Player.Forward_Off += this.ZOff;
		CharacterMove.Player.Backward_On += this.Backward;
		CharacterMove.Player.Backward_Off += this.ZOff;
		CharacterMove.Player.Strafe_Left_On += this.StrafeLeft;
		CharacterMove.Player.Strafe_Left_Off += this.XOff;
		CharacterMove.Player.Strafe_Right_On += this.StrafeRight;
		CharacterMove.Player.Strafe_Right_Off += this.XOff;
	}

	public void Forward() { this.positionControl.move.Forward(); }
	public void Backward() { this.positionControl.move.Backward(); }
	public void StrafeLeft() { this.positionControl.move.Left(); }
	public void StrafeRight() { this.positionControl.move.Right(); }
	public void XOff() { this.positionControl.move.XOff(); }
	public void ZOff() { this.positionControl.move.ZOff(); }
}
