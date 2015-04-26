using Ninject;
using Ninject.Activation;
using System;

namespace Ninject.Unity
{
	/// <summary>
	/// Standard settings for used by the UnityKernel.
	/// </summary>
	public class StandardSettings : INinjectSettings
	{
		private TimeSpan cachePruningInterval = new TimeSpan(0, 0, 10);

		public bool ActivationCacheDisabled
		{
			get;
			set;
		}

		public bool AllowNullInjection
		{
			get;
			set;
		}

		public TimeSpan CachePruningInterval
		{
			get
			{
				return cachePruningInterval;
			}
		}

		public Func<IContext, object> DefaultScopeCallback
		{
			get
			{
				return null;
			}
		}

		public string[] ExtensionSearchPatterns
		{
			get
			{
				return new string[0];
			}
		}

		public Type InjectAttribute
		{
			get
			{
				return typeof(InjectAttribute);
			}
		}

		public bool InjectNonPublic
		{
			get
			{
				return true;
			}

			set
			{
			}
		}

		public bool InjectParentPrivateProperties
		{
			get
			{
				return true;
			}

			set
			{
			}
		}

		public bool LoadExtensions
		{
			get
			{
				return true;
			}
		}

		public bool UseReflectionBasedInjection
		{
			get
			{
				return true;
			}
		}

		public T Get<T>(string key, T defaultValue)
		{
			return default(T);
		}

		public void Set(string key, object value)
		{
		}
	}
}