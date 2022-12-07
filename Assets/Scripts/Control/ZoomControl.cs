using UnityEngine;

public class ZoomControl : TransformBase {

	[SerializeField]
	private float _distance;
	public float distance { 
		get => this._distance;
		set => this._distance = value;
	}

	public void Start() {
		this.distance = Mathf.Abs(this.transform.position.z);
		this.initActionListener(this);
	}

	public void In() => this.distance -= this.step;
	public void Out() => this.distance += this.step;

	public void Update() {
		if(Mathf.Abs(this.transform.localPosition.z) != this.distance) {
			this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,
																									new Vector3(this.transform.localPosition.x,
																															this.transform.localPosition.y,
																														 -this.distance),
																									Time.deltaTime * this.duration);
		}
	}
}
