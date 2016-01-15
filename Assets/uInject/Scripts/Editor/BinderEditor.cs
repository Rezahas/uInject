using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Ninject.Unity.Editor
{
	[CustomEditor(typeof(Binder))]
	public class BinderEditor : UnityEditor.Editor
	{
		private int namespaceId;
		private string[] namespaces;
		private Dictionary<string, string[]> types;

		private int typeId;

		public override void OnInspectorGUI()
		{
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Namespace");
			namespaceId = EditorGUILayout.Popup(namespaceId, namespaces);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Type");
			typeId = EditorGUILayout.Popup(typeId, types[namespaces[namespaceId]]);
			EditorGUILayout.EndHorizontal();

			if (EditorGUI.EndChangeCheck())
			{
				EditorUtility.SetDirty(target);
			}
		}

		private static Assembly GetAssembly()
		{
			return typeof(UnityKernel).Assembly;
		}

		private void Awake()
		{
			GetNamespaces();
			GetTypes();
		}

		private void GetNamespaces()
		{
			namespaces = GetAssembly().GetTypes().Where(t => t.Namespace != null).Select(t => t.Namespace).Distinct().ToArray();
		}

		private void GetTypes()
		{
			types = namespaces.ToDictionary(
				n => n,
				n => GetAssembly().GetTypes().Where(t => !t.IsNested && t.Namespace != null && t.Namespace.Equals(n)).Select(t => t.Name).ToArray()
				);
		}
	}
}