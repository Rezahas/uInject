using System;
using UnityEngine;

namespace Ninject.Unity
{
	/// <summary>
	/// Binds a type to a Scriptable Object.
	/// </summary>
	[Serializable]
	public class ScriptableObjectBinding
	{
		public string type;
		public ScriptableObject scriptableObject;
	}
}