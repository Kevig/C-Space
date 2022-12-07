using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : IEvent {

	private dynamic _control;
	public dynamic control {
		get => this._control;
		set => this._control = value;
	}

	private ControlledBy _controller;
	public ControlledBy controller {
		get => this._controller;
		set => this._controller = value;
	}

	public class Player {
		public delegate void PlayerMove();
		
		public static event PlayerMove
			Forward_On, Forward_Off,
			Backward_On, Backward_Off,
			Strafe_Left_On, Strafe_Left_Off,
			Strafe_Right_On, Strafe_Right_Off;

		private CharacterMove _owner;
		public CharacterMove owner {
			get => this._owner;
			set => this._owner = value;
		}

		public Player(CharacterMove characterMove) { this.owner = characterMove; }

		public void Forward(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Forward_On(); }
			else { Forward_Off(); }
		}
		public void Backward(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Backward_On(); }
			else { Backward_Off(); }
		}
		public void StrafeLeft(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Strafe_Left_On(); }
			else { Strafe_Left_Off(); }	
		}
		public void StrafeRight(InputState state) {
			if(state == InputState.Down || state == InputState.Hold) { Strafe_Right_On(); }
			else { Strafe_Right_Off(); }
		}

		public override string ToString() { return "Character Move - Controlled By Player"; }
	}

	public class AI {

		/*
		public delegate void AIMove();
		
		public static event AIMove
			Forward_On, Forward_Off,
			Backward_On, Backward_Off,
			Strafe_Left_On, Strafe_Left_Off,
			Strafe_Right_On, Strafe_Right_Off;

		*/
		private CharacterMove _owner;
		public CharacterMove owner {
			get => this._owner;
			set => this._owner = value;
		}

		public AI(CharacterMove characterMove) { this.owner = characterMove; }

		public override string ToString() { return "Character Move - Controlled By AI"; }

	}

	public CharacterMove(ControlledBy controlledBy) {
		this.controller = controlledBy;
		switch(controlledBy) {
			case ControlledBy.Player: this.control = new CharacterMove.Player(this); break;
		}
	}

	public void Trigger(InputItem inputItem)
	{
		this.TriggerEvent(inputItem.keyCode, inputItem.state);
	}

	public void TriggerEvent(KeyCode direction, InputState state)
	{
		if(this.controller == ControlledBy.Player) {
			switch(direction) {
				case KeyCode.W: this.control.Forward(state); break;
				case KeyCode.S: this.control.Backward(state); break;
				case KeyCode.A: this.control.StrafeLeft(state); break;
				case KeyCode.D: this.control.StrafeRight(state); break;
			}
		}

		
	}
}
