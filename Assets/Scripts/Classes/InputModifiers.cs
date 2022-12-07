using UnityEngine;

[System.Serializable]
public class InputModifiers {
  
	[SerializeField]
	private KeyCode[] _keys;
	public KeyCode[] keys {
		get => this._keys;
		set => this._keys = value;
	}

	[SerializeField]
	private bool _state;
	public bool state {
		get => this.state = (this.keys == null) ? true : this.isActive();
		set => this._state = value;
	}

	private bool _useModifiers;
	public bool useModifiers {
		get => this._useModifiers;
		set => this._useModifiers = value;
	}

	public InputModifiers(KeyCode[] keys, bool useModifiers) {
		this.keys = keys;
		this.state = false;
		this.useModifiers = useModifiers;
	}

	private bool isActive() {
		bool result = true;
		int n = this.keys.Length;
		for(int i=0; i<n; i++) {
			if(!Input.GetKey(this.keys[i])) {
				result = false;
				break;
			}
		}
		if(!useModifiers) { result = !result; }
		return result;
	}

	public override string ToString() {
		string result = "";
		if(this.keys != null && this.useModifiers) {
			int n = this.keys.Length;
			for(int i=0; i<n; i++) {
				result += this.keys[i].ToString() + "+";
			}	
		}
		return result;
	}
}
