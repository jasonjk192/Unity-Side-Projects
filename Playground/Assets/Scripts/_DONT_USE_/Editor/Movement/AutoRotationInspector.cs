using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(AutoRotation))]
public class AutoRotationInspector : BaseInspectorWindow
{
	private string explanation = "The gameObject rotates automatically.";
	private string tip = "TIP: Use negative value to rotate in the other direction.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		EditorGUILayout.HelpBox(tip, MessageType.Info);
	}
}