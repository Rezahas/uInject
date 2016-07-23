using Ninject.Unity.Internal;
using UnityEditor;
using UnityEngine;

namespace Ninject.Unity.Editor
{
	[CustomEditor(typeof(Settings))]
	public class SettingsEditor : UnityEditor.Editor
	{
		private const string SETTINGS_NAME = "uInject Options";
		private static Settings instance;
		private string newModuleName = "New Module";

		private static Settings Instance
		{
			get
			{
				if (instance == null)
				{
					instance = (Settings)Resources.Load(SETTINGS_NAME);
				}
				return instance;
			}
		}

		[MenuItem("Window/uInject/Options")]
		public static void Edit()
		{
			UnityEditor.Selection.activeObject = Instance;
		}

		public override void OnInspectorGUI()
		{
			DrawNewModule();
			EditorGUILayout.Separator();
			DrawPackage();
		}

		private static void DrawPackage()
		{
			if (GUILayout.Button("Export Unity Package"))
			{
				ExportPackageOptions options = ExportPackageOptions.Interactive | ExportPackageOptions.Recurse;
				AssetDatabase.ExportPackage("Assets/uInject", "uInject.unitypackage", options);
			}
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