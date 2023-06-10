using UnityEngine;

namespace LearningArchive.Example
{
    public class GameObjectSimplifyExample
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/005.GameObject Active 简化", false, 5)]
#endif
        private static void MenuClicked()
        {
            GameObject gameObject = new GameObject();

            gameObject.Hide();
            gameObject.transform.Hide();
        }
    }
}
