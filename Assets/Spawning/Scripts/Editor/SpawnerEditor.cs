using UnityEditor;
using UnityEngine;

namespace Spawning.Editor
{
	[CustomEditor(typeof(ASpawnerMono), true)]
	public class SpawnerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (EditorApplication.isPlaying && GUILayout.Button("Spawn"))
			{
				Spawner spawner = (Spawner)target;
				spawner.Spawn();
			}
		}
	}
}