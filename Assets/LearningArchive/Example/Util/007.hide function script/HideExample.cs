using UnityEngine;

namespace LearningArchive.Example
{
    public class HideExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/007.Hide 脚本", false, 7)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject().AddComponent<Hide>();
        }
#endif
    }
}
