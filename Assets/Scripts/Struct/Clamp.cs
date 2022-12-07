using UnityEngine;

[System.Serializable]
public class Clamp {
	
	[SerializeField]
	public bool clamped;
	
	[SerializeField]
	public float value;

	[SerializeField]
	public float min;
	
	[SerializeField]
	public float max;

	public Clamp(bool b, float f) {
		this.clamped = b;
		this.value = f;
	}

}