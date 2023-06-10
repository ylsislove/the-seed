using UnityEngine;

namespace LearningArchive.Example
{
    public class SingletonExample : Singleton<SingletonExample>
    {
        private SingletonExample()
        {
            Debug.Log("singleton example ctor");
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/008.SingletonExample", false, 8)]
        static void MenuClicked()
        {
            var initInstance = SingletonExample.Instance;
            initInstance = SingletonExample.Instance;
        }
#endif
    }
}
