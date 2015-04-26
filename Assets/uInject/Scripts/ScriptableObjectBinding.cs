using System;
using UnityEngine;

namespace uInject
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