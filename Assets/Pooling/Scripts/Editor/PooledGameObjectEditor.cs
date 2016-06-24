using UnityEditor;
using UnityEngine;

namespace Pools.Editor
{
	[CustomEditor(typeof(PooledGameObject))]
	public class PooledGameObjectEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (EditorApplication.isPlaying && GUILayout.Button("Return"))
			{
				PooledGameObject pgo = (PooledGameObject)target;
				pgo.ReturnToPool();
			}
		}
	}
}