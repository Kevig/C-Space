using UnityEngine;

[System.Serializable]
public struct InputDisplay {
	[SerializeField]
	private string _input;
	public string input {
		get => this._input;
		set => this._input = value;
	}

	[SerializeField]
	private string _action;
	public string action {
		get => this._action;
		set => this._action = value;
	}

	public InputDisplay(string input, string action) {
		this._input = input;
		this._action = action;
	}
}
