using System.Collections.Generic;
using UnityEngine;

namespace Ninject.Unity.Internal
{
	public class Settings : ScriptableObject
	{
		public string packageName;
		public List<string> exportPaths = new List<string>();
	}
}