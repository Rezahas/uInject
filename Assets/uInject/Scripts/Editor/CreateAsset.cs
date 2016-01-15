﻿using UnityEditor;
using UnityEngine;

namespace Ninject.Unity.Editor
{
	public class CreateAsset
	{
		[MenuItem("Assets/Create/Scriptable Object")]
		public static void CreateScriptableObject()
		{
			ScriptableObject so = ScriptableObject.CreateInstance<ScriptableObject>();
			AssetDatabase.CreateAsset(so, "Assets/NewScriptableObject.asset");
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
			UnityEditor.Selection.activeObject = so;
		}
	}
}