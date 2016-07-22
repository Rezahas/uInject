using Ninject.Unity.Internal;
using UnityEditor;
using UnityEngine;

namespace Ninject.Unity.Editor
{
	[CustomEditor(typeof(Settings))]
	public class SettingsEditor : UnityEditor.Editor
	{
		private string newModuleName = "New Module";

		public override void OnInspectorGUI()
		{
			DrawNewModule();
		}

		private void DrawNewModule()
		{
			EditorGUILayout.LabelField("New Module");
			newModuleName = EditorGUILayout.TextField(newModuleName);
			if (GUILayout.Button("Create"))
			{
				ModuleFactory.CreateModule(newModuleName);
			}
		}
	}
}