using UnityEngine;

namespace LearningArchive.Example
{
	public class LoadABAssetExample : MonoBehaviour
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("LearningArchive/Example/Util/011.LoadABAssetExample", false, 11)]
		static void MenuClicked()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject("LoadABAssetExample")
				.AddComponent<LoadABAssetExample>();
		}
#endif

		private ResLoader mResLoader = new ResLoader();
		
		// Use this for initialization
		void Start()
		{
			var squareTexture = mResLoader.LoadSync<Texture2D>("square", "Square");
			Debug.Log(squareTexture.name);
			
			mResLoader.LoadAsync<GameObject>("gameobject","GameObject",
				gameObjPrefab => { Instantiate(gameObjPrefab); });
		}

		private void OnDestroy()
		{
			mResLoader.ReleaseAll();
			mResLoader = null;
		}
	}
}