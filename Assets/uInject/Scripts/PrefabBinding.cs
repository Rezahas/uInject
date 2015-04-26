using System;
using UnityEngine;

namespace uInject
{
	/// <summary>
	/// Binds a type to a prefab.
	/// </summary>
	[Serializable]
	public class PrefabBinding
	{
		public string type;
		public GameObject prefabs;
	}
}