using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Number {
  
	public static int getDecimalPlaces(float value) {
		string number = value.ToString();
		int index = number.IndexOf(".");
		int decimalPlaces = 0;
		if(index != -1) { decimalPlaces = number.Substring(index).Length; }
		return decimalPlaces;
	}

	public static float Round(float value, int step) {
		return (float) System.Math.Round(value, step);
	}

	public static Vector3 Round(Vector3 value, int step) {
		return new Vector3(Number.Round(value.x, step), Number.Round(value.y, step), Number.Round(value.z, step));
	}

//	public static Vector3 Round(Vector3 v, int s) {
//		return new Vector3(Number.Round(v.x, s), Number.Round(v.y, s), Number.Round(v.z, s));
//	}

}
