using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ninject.Unity.Internal
{
	public static class ModuleFactory
	{
		private const string TEST_DIR_NAME = "Test";
		private const string PREFAB_DIR_NAME = "Prefabs";
		private const string SCENES_DIR_NAME = "Scenes";
		private const string BINDINGS_DIR_NAME = "Bindings";
		private const string SCRIPTS_DIR_NAME = "Scripts";
		private const string INTERFACES_DIR_NAME = "Interfaces";
		private const string IMPLEMENTATIONS_DIR_NAME = "Implementations";

		public static void CreateModule(string moduleName)
		{
			moduleName = moduleName.Replace(' ', '_');
			string modulePath = GetNewModuleFolder(moduleName);
			string testPath = Path.Combine(modulePath, TEST_DIR_NAME);
			string scriptPath = Path.Combine(modulePath, SCRIPTS_DIR_NAME);
			Directory.CreateDirectory(modulePath);
			CreateSubDirs(modulePath, SCRIPTS_DIR_NAME, TEST_DIR_NAME, PREFAB_DIR_NAME, SCENES_DIR_NAME, BINDINGS_DIR_NAME);
			CreateSubDirs(testPath, PREFAB_DIR_NAME, SCENES_DIR_NAME, SCRIPTS_DIR_NAME);
			CreateSubDirs(scriptPath, INTERFACES_DIR_NAME, IMPLEMENTATIONS_DIR_NAME);
			CreateBinderMono(moduleName, scriptPath);
			CreateBinderPrefab(moduleName, Path.Combine(modulePath, BINDINGS_DIR_NAME));
			AssetDatabase.Refresh();
		}

		private static string GetNewModuleFolder(string name)
		{
			string location = Application.dataPath;
			string modulePath = Path.Combine(location, name);
			if (Directory.Exists(modulePath))
			{
				int id = 1;
				while (Directory.Exists(Path.Combine(location, name + " " + id)))
				{
					id++;
				}
				modulePath += " " + id;
			}
			return modulePath;
		}

		private static string GetCurrentDirectory()
		{
			string path = AssetDatabase.GetAssetPath(UnityEditor.Selection.activeObject);
			if (string.IsNullOrEmpty(path))
			{
				return path;
			}
			else
			{
				FileAttributes att = File.GetAttributes(path);
				if (att == FileAttributes.Directory)
				{
					return path;
				}
				else
				{
					return Path.GetDirectoryName(path);
				}
			}
		}

		private static void CreateSubDirs(string dir, params string[] subdirs)
		{
			foreach (string s in subdirs)
			{
				Directory.CreateDirectory(Path.Combine(dir, s));
			}
		}

		private static void CreateBinderMono(string moduleName, string scriptPath)
		{
			string className = moduleName + "Binder";
			string fileName = className + ".cs";
			string binderTemplate = Path.Combine(Application.dataPath, "uInject/Res/BinderTemplate.cs");
			string binderMono = Path.Combine(scriptPath, fileName);
			StreamReader reader = new StreamReader(new FileStream(binderTemplate, FileMode.Open));
			StreamWriter writer = new StreamWriter(File.Create(binderMono));
			string line;
			while (!reader.EndOfStream)
			{
				line = reader.ReadLine();
				line = line.Replace("TemplateNamespace", moduleName);
				line = line.Replace("BinderTemplate", className);
				writer.WriteLine(line);
			}
			reader.Close();
			writer.Close();
		}

		private static void CreateBinderPrefab(string moduleName, string bindingsPath)
		{
			string prefabName = "Default";
			string name = prefabName + ".prefab";
			string prefabPath = Path.Combine("Assets", moduleName);
			prefabPath = Path.Combine(prefabPath, BINDINGS_DIR_NAME);
			prefabPath = Path.Combine(prefabPath, name);
			prefabPath = prefabPath.Replace('\\', '/');
			GameObject prefab = new GameObject(prefabName);
			PrefabUtility.CreatePrefab(prefabPath, prefab);
			Object.DestroyImmediate(prefab);
		}
	}
}