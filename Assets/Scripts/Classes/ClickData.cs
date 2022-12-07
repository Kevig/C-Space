using UnityEngine;

public class ClickData {

	private GameObject _gameObject;
	public GameObject gameObject {
		get => this._gameObject;
		set => this._gameObject = value;
	}

	private Vector3 _location;
	public Vector3 location {
		get => this._location;
		set => this._location = value;
	}

	public ClickData(GameObject gameObject, Vector3 location) {
		this.gameObject = gameObject;
		this.location = location;
	}

	public static ClickData get() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) {
			return new ClickData(hit.collider.gameObject, hit.point);
		} else { return null; }
	}

}