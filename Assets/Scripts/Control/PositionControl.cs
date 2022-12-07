using UnityEngine;

public class PositionControl : TransformControl {

	private Move _move;
	public Move move {
		get => this._move;
	}

	public void Start() {
		this._move = new Move(this);
		this.initActionListener(this);
	}

	protected override void Animate(Vector3 target, float time) {
		this.transform.Translate(target * time, this.space);
	}

	protected override Vector3 GetVectors() => this.transform.position;
	protected override void SetVectors(Vector3 vectors) => this.transform.position = vectors;

	public void SetPosition(Vector3 position, float Duration) {
		this.ChangeVectors(position, duration);
	}

	public class Move {
		private PositionControl _positionControl;
		public PositionControl positionControl {
			get => this._positionControl;
			set => this._positionControl = value;
		}

		public Vector3 target {
			get => this.positionControl.targetVector;
			set => this.positionControl.targetVector = value;
		}


		public Move(PositionControl positionControl) => this.positionControl = positionControl;
		
		public void Forward() => this.target = new Vector3(this.target.x, this.target.y, 1f);
		public void Backward() =>	this.target = new Vector3(this.target.x, this.target.y, -1f);
		public void Left() =>	this.target = new Vector3(-1f, this.target.y, this.target.z);
		public void Right() => this.target = new Vector3(1f, this.target.y, this.target.z);
		public void Up() => this.target = new Vector3(this.target.x, 1f, this.target.z);
		public void Down() => this.target = new Vector3(this.target.x, -1f, this.target.z);
		public void XOff() {
			Vector3 position = this.positionControl.targetVector;
			position.x = 0f;
			this.positionControl.targetVector = position;
		}
		public void ZOff() {
			Vector3 position = this.positionControl.targetVector;
			position.z = 0f;
			this.positionControl.targetVector = position;
		}
	}

}
