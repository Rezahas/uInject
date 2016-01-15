using System.IO;
using UnityEditor;
using UnityEngine;

namespace Ninject.Unity.Editor
{
	public class ModuleEditor
	{
		private const string TEST_DIR_NAME = "Test";
		private const string PREFAB_DIR_NAME = "Prefabs";
		private const string SCENES_DIR_NAME = "Scenes";
		private const string BINDINGS_DIR_NAME = "Bindings";
		private const string SCRIPTS_DIR_NAME = "Scripts";
		private const string INTERFACES_DIR_NAME = "Interfaces";
		private const string IMPLEMENTATIONS_DIR_NAME = "Implementations";
		private const string MODULES_XML_NAME = "modules.xml";
		private static string modulesXml;

		public static string ModulesXml
		{
			get
			{
				if (string.IsNullOrEmpty(modulesXml))
				{
					modulesXml = FindModulesXml();
				}
				return modulesXml;
			}
			private set
			{
				modulesXml = value;
			}
		}

		public static string FindModulesXml()
		{
			string[] files = Directory.GetFiles(Application.dataPath, MODULES_XML_NAME, SearchOption.AllDirectories);
			if (files.Length > 0)
			{
				return files[0];
			}
			else
			{
				return null;
			}
		}

		[MenuItem("uInject/Create Modules Folder")]
		[MenuItem("Assets/Create/Modules Folder")]
		private static void CreateModulesFolder()
		{
			bool create = true;
			if (ModulesExist())
			{
				create = EditorUtility.DisplayDialog("Modules already exist", "The Modules folder already exists, creating a new one will most likely break your application. Continue?", "Yes", "No");
			}
			if (create)
			{
				string dir = GetCurrentDirectory();
				if (string.IsNullOrEmpty(dir))
				{
					dir = Application.dataPath;
				}
				string path = Path.Combine(dir, "Modules");
				Directory.CreateDirectory(path);
				ModulesXml = Path.Combine(path, MODULES_XML_NAME);
				FileStream s = File.Create(ModulesXml);
				s.Close();
				AssetDatabase.Refresh();
			}
		}

		private static bool ModulesExist()
		{
			return !string.IsNullOrEmpty(ModulesXml);
		}

		private static string GetModulesFolder()
		{
			return Path.GetDirectoryName(modulesXml);
		}

		[MenuItem("uInject/New Module")]
		private static void NewModule()
		{
			if (ModulesExist())
			{
				string modulePath = GetNewModuleFolder();
				string testPath = Path.Combine(modulePath, TEST_DIR_NAME);
				string scriptPath = Path.Combine(modulePath, SCRIPTS_DIR_NAME);
				Directory.CreateDirectory(modulePath);
				Directory.CreateDirectory(testPath);
				Directory.CreateDirectory(scriptPath);
				CreateSubDirs(modulePath, PREFAB_DIR_NAME, SCENES_DIR_NAME, BINDINGS_DIR_NAME);
				CreateSubDirs(testPath, PREFAB_DIR_NAME, SCENES_DIR_NAME, SCRIPTS_DIR_NAME);
				CreateSubDirs(scriptPath, INTERFACES_DIR_NAME, IMPLEMENTATIONS_DIR_NAME);
				Select(modulePath);
			}
		}

		private static void Select(string modulePath)
		{
			AssetDatabase.Refresh();
			Object o = AssetDatabase.LoadAssetAtPath(modulePath.Replace(Application.dataPath, "Assets"), typeof(Object));
			UnityEditor.Selection.activeObject = o;
		}

		private static string GetNewModuleFolder()
		{
			string location = GetModulesFolder();
			string dir = "New Module";
			string modulePath = Path.Combine(location, dir);
			if (Directory.Exists(modulePath))
			{
				int id = 1;
				while (Directory.Exists(Path.Combine(location, dir + " " + id)))
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
	}
}