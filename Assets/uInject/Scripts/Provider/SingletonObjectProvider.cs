namespace Ninject.Unity.Provider
{
	public class SingletonObjectProvider<T> : SingletonProvider<T> where T : new()
	{
		protected override T CreateInstance()
		{
			return new T();
		}
	}
}