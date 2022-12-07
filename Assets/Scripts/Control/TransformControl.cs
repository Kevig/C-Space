using System.Collections;
using UnityEngine;

public class TransformControl : TransformBase {

	[Space]
	[SerializeField]
	private Space _space;
	public Space space {
		get => this._space;
		set => this._space = value;
	}

	[Space]
	[SerializeField]
	private Vector3 _targetVector;
	public Vector3 targetVector {
		get => this._targetVector;
		set => this._targetVector = value;
	}

	[Space]
	[SerializeField]
	private bool _repeat;
	public bool repeat {
		get => this._repeat;
		set => this._repeat = value;
	}

	[SerializeField]
	private Coroutine _coroutine;
	public Coroutine coroutine {
		get => this._coroutine;
		set => this._coroutine = value;
	}

	[SerializeField]
	[ReadOnly]
	private bool _animating;
	public bool animating {
		get => this._animating;
		set => this._animating = value;
	}

	[SerializeField]
	private bool _active;
	public bool active {
		get => this._active;
		set => this._active = value;
	}

	[SerializeField]
	private Vector3Clamp _clamp;
	public Vector3Clamp clamp {
		get => this._clamp;
		set => this._clamp = value;
	}

	protected virtual void Animate(Vector3 target, float time) { }
	protected virtual Vector3 GetVectors() { return Vector3.zero; }
	protected virtual void SetVectors(Vector3 vectors) { }

	private IEnumerator IRoutine(Vector3 vector3, float fDuration) {
		Vector3 target = vector3;
		float duration = fDuration;
		float elapsed = 0f;
		while(elapsed <= duration) {
			while(!this.active) {
				yield return null;
			}
			elapsed += Time.deltaTime;
			float time = (duration <= 0f) ? 1f : Time.deltaTime / duration;
			this.Animate(target, time);
			this.ClampAxes(this.GetVectors());
			yield return null;
		}
		this.FixVectors(this.GetVectors());
		this.animating = false;
		if(!this.repeat) { this.targetVector = Vector3.zero; }	
	}

	protected void FixVectors(Vector3 vectors) {
		this.SetVectors(Number.Round(vectors, Number.getDecimalPlaces(this.step)));
	}

	private void ClampAxes(Vector3 target) {
		Vector3 vectors = target;
		vectors.x = (this.clamp.x.clamped) ? this.clamp.x.value : vectors.x;
		vectors.y = (this.clamp.y.clamped) ? this.clamp.y.value : vectors.y;
		vectors.z = (this.clamp.z.clamped) ? this.clamp.z.value : vectors.z;
		this.SetVectors(vectors);
	}

	protected void ChangeVectors(Vector3 newVectors, float duration) {
		if(!this.animating) {
			this.animating = true;
			this.coroutine = StartCoroutine(this.IRoutine(newVectors, duration));
		}
	}
	
	public virtual void Update() {
		if(this.active) {
			if(this.targetVector != Vector3.zero && !this.animating) {
				this.animating = true;
				this.coroutine = StartCoroutine(this.IRoutine(this.targetVector * this.step, this.duration));
			}
		}
	}
	
}
