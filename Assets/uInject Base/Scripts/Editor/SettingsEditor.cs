using Ninject.Unity.Internal;
using System.Linq;
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
			DrawExportUInject();
			EditorGUILayout.Separator();
			DrawExportModules();
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

		private void DrawExportUInject()
		{
			EditorGUILayout.LabelField("Export uInject Unity Package");
			if (GUILayout.Button("Export"))
			{
				ExportPackageOptions options = ExportPackageOptions.Interactive | ExportPackageOptions.Recurse;
				AssetDatabase.ExportPackage("Assets/uInject Base", "uInject.unitypackage", options);
			}
		}

		private void DrawExportModules()
		{
			Settings s = (Settings)target;
			if (s.exportPaths.Count == 0 || s.exportPaths.Last() != "")
			{
				s.exportPaths.Add("");
			}
			EditorGUILayout.LabelField("Export Modules");
			for (int i = 0; i < s.exportPaths.Count; i++)
			{
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.PrefixLabel("Module");
				s.exportPaths[i] = EditorGUILayout.TextField(s.exportPaths[i]);
				if (GUILayout.Button("X"))
				{
					s.exportPaths.RemoveAt(i);
				}
				EditorGUILayout.EndHorizontal();
			}
			EditorGUILayout.PrefixLabel("Module");
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Package Name");
			s.packageName = EditorGUILayout.TextField(s.packageName);
			EditorGUILayout.EndHorizontal();
			if (GUILayout.Button("Export"))
			{
				if (!s.packageName.EndsWith(".unitypackage"))
				{
					s.packageName += ".unitypackage";
				}
				s.exportPaths.RemoveAt(s.exportPaths.Count - 1);
				for (int i = 0; i < s.exportPaths.Count; i++)
				{
					if (!s.exportPaths[i].StartsWith("Assets/"))
					{
						s.exportPaths[i] = "Assets/" + s.exportPaths[i];
					}
				}
				ExportPackageOptions options = ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies;
				AssetDatabase.ExportPackage(s.exportPaths.ToArray(), s.packageName, options);
			}
		}
	}
}