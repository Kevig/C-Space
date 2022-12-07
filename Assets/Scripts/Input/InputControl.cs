using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputControl : MonoBehaviour {

	[SerializeField]
	public List<InputDisplay> inputs;

	public void Start() {
		this.inputs = new List<InputDisplay>();

		CameraRotate pivot = new CameraRotate(RotationTarget.Pivot);
			this.inputs.Add(InputItem.Create( this.gameObject, pivot, KeyCode.UpArrow, new KeyCode[] { KeyCode.LeftShift }, false));
			this.inputs.Add(InputItem.Create(	this.gameObject, pivot, KeyCode.DownArrow, new KeyCode[] { KeyCode.LeftShift }, false));
			this.inputs.Add(InputItem.Create(	this.gameObject, pivot, KeyCode.LeftArrow, new KeyCode[] { KeyCode.LeftShift }, false));
			this.inputs.Add(InputItem.Create(	this.gameObject, pivot, KeyCode.RightArrow, new KeyCode[] { KeyCode.LeftShift }, false));
			this.inputs.Add(InputItem.Create(	this.gameObject, pivot, KeyCode.Mouse0, new KeyCode[] { KeyCode.LeftShift }, false));

		CameraRotate self = new CameraRotate(RotationTarget.Self);
			this.inputs.Add(InputItem.Create( this.gameObject, self, KeyCode.UpArrow, new KeyCode[] { KeyCode.LeftShift }, true));
			this.inputs.Add(InputItem.Create(	this.gameObject, self, KeyCode.DownArrow, new KeyCode[] { KeyCode.LeftShift }, true));
			this.inputs.Add(InputItem.Create(	this.gameObject, self, KeyCode.LeftArrow, new KeyCode[] { KeyCode.LeftShift }, true));
			this.inputs.Add(InputItem.Create(	this.gameObject, self, KeyCode.RightArrow, new KeyCode[] { KeyCode.LeftShift }, true));
			this.inputs.Add(InputItem.Create(	this.gameObject, self, KeyCode.Mouse0, new KeyCode[] { KeyCode.LeftShift }, true));

		CameraZoom zoom = new CameraZoom();
			this.inputs.Add(InputItem.Create( this.gameObject, zoom, KeyCode.None, null, false));

		CharacterMove character = new CharacterMove(ControlledBy.Player);
			this.inputs.Add(InputItem.Create( this.gameObject, character, KeyCode.W, null, false));
			this.inputs.Add(InputItem.Create( this.gameObject, character, KeyCode.S, null, false));
			this.inputs.Add(InputItem.Create( this.gameObject, character, KeyCode.A, null, false));
			this.inputs.Add(InputItem.Create( this.gameObject, character, KeyCode.D, null, false));
	}

}
