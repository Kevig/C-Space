using System.Collections;
using UnityEngine;

[SerializeField]
public class InputItem : MonoBehaviour {
  
	private static float holdThreshold = 0.25f;

	[SerializeField]
	private KeyCode _keyCode;
	public KeyCode keyCode {
		get => this._keyCode;
		set => this._keyCode = value;
	}

	[SerializeField]
	private InputModifiers _modifiers;
	public InputModifiers modifiers {
		get => this._modifiers;
		set => this._modifiers = value;
	}

	private bool _hasModifiers;
	public bool hasModifiers {
		get => this._hasModifiers;
		set => this._hasModifiers = value;
	}

	[SerializeField]
	private InputState _state;
	public InputState state {
		get => this._state;
		set => this._state = value;
	}

	[SerializeField]
	private dynamic _inputEvent;
	public dynamic inputEvent {
		get => this._inputEvent;
		set => this._inputEvent = value;
	}

	private Coroutine _holdTimer = null;
	public Coroutine holdTimer {
		get => this._holdTimer;
		set => this._holdTimer = value;
	}

	public static InputDisplay Create(GameObject gameObject, dynamic inputEvent, KeyCode keyCode, KeyCode[] modifiers, bool useModifiers) {
		InputItem inputItem = gameObject.AddComponent<InputItem>();
		return inputItem.Init(inputEvent, keyCode, modifiers, useModifiers);
	}

	public InputDisplay Init(dynamic inputEvent, KeyCode keyCode, KeyCode[] modifiers, bool useModifiers) {
		this.inputEvent = inputEvent;
		this.keyCode = keyCode;
		this.hasModifiers = true;
		this.modifiers = new InputModifiers(modifiers, useModifiers);
		return this.ToInputDisplay();
	}

	public void Start() {
		this.hideFlags = HideFlags.HideInInspector;
	}

	public void Update() {
		
		if(this.CheckModifiers()) {
			if(Input.GetKeyUp(this.keyCode)) {
					this.KeyEvent(InputState.Up, false);
					this.inputEvent.Trigger(this);
			}

			if(Input.GetKeyDown(this.keyCode)) {
				this.KeyEvent(InputState.Down, true);
			}
			
			if(Input.GetKey(this.keyCode)) {
				this.inputEvent.Trigger(this);
			}
			
			if(this.keyCode == KeyCode.None) {
				float scrollWheelDirection = Input.mouseScrollDelta.y;
				if(scrollWheelDirection != 0) {
					if(scrollWheelDirection > 0) { this.inputEvent.Trigger(Direction.In); }
					else { this.inputEvent.Trigger(Direction.Out); }
				}
			}
		}
	}

	private bool CheckModifiers() {
		if(this.hasModifiers) {
			return this.modifiers.state;
		} else { return true; }
	}

	private void KeyEvent(InputState inputState, bool requireHoldTimer) {
		this.state = inputState;
		this.HoldTimer(requireHoldTimer);
	}

	private void HoldTimer(bool status) {
		if(this.holdTimer != null) { StopCoroutine(this.holdTimer); }
		if(status) { this.holdTimer = StartCoroutine(this.Hold(this.keyCode)); }
		else { this.holdTimer = null; }
	}

	private IEnumerator Hold(KeyCode key) {
		yield return new WaitForSeconds(InputItem.holdThreshold);
		if(Input.GetKey(key)) { this.state = InputState.Hold; }
	}

	public InputDisplay ToInputDisplay() {
		string modifier = this.modifiers.ToString();
		string key = this.keyCode.ToString();
		
		if(key.Equals("Mouse0")) { key = "Mouse Left"; }

		string result = "";
		if(modifier != "") { result += modifier + " "; }
		result += key;

		return new InputDisplay(result, this.inputEvent.ToString());
	}

	public override string ToString() {
		return 	"Input: " + this.modifiers.ToString() +
						this.keyCode.ToString() + " " +
						"Action: " + this.inputEvent.ToString();
	}

}
