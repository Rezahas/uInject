using System;
using UnityEngine;

namespace Ninject.Unity
{
	/// <summary>
	/// Binds types.
	/// </summary>
	[Serializable]
	public class ClassBinding
	{
		public string @interface;
		public string @implementation;
		public bool singleton;
	}
}