using UnityEngine;

[System.Serializable]
public class Vector3Clamp {

	[SerializeField]
	private Clamp _x;
	public Clamp x { 
		get => this._x;
		set => this._x = value;
	}

	[SerializeField]
	private Clamp _y;
	public Clamp y { 
		get => this._y;
		set => this._y = value;
	}

	[SerializeField]
	private Clamp _z;
	public Clamp z {
		get => this._z;
		set => this._z = value;
	}

	public Vector3Clamp() {
		this.x = new Clamp(false, 0f);
		this.y = new Clamp(false, 0f);
		this.z = new Clamp(false, 0f);
	}

	public Vector3Clamp(Clamp x, Clamp y, Clamp z) {
		this.x = x;
		this.y = y;
		this.z = z;
	}

}
