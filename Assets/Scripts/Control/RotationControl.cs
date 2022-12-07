using UnityEngine;

public class RotationControl : TransformControl {

	public void Start() {
		this.initActionListener(this);
	}

	protected override void Animate(Vector3 target, float time) {
		this.transform.Rotate(target / time, this.space);
	}

	protected override Vector3 GetVectors() => this.transform.eulerAngles;
	protected override void SetVectors(Vector3 vectors) => this.transform.eulerAngles = vectors;
	
	public void SetRotation(Vector3 rotation, float duration) {
		this.ChangeVectors(rotation, duration);
	}
}
