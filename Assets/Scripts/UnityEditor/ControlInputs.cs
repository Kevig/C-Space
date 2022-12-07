using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(InputControl))]
public class ControlInputs : Editor {

	InputControl inputControl;
	SerializedObject obj;
	SerializedProperty list;

	public void OnEnable() {
		this.inputControl = (InputControl) target;
		this.obj = new SerializedObject(target);
		this.list = this.obj.FindProperty("inputs");
	}

  public override void OnInspectorGUI () {
		this.obj.Update();
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Key / Button:                  Action:", EditorStyles.boldLabel);
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		for(int i=0; i<this.list.arraySize; i++) {
			SerializedProperty item = this.list.GetArrayElementAtIndex(i);
			SerializedProperty keys = item.FindPropertyRelative("_input");
			SerializedProperty action = item.FindPropertyRelative("_action");
			
			if(keys.stringValue.Equals("None")) { keys.stringValue = "Mouse Scroll Wheel"; }
			EditorGUILayout.LabelField(keys.stringValue, action.stringValue);
			EditorGUILayout.Space();
		}
		this.obj.ApplyModifiedProperties();
	}
}
