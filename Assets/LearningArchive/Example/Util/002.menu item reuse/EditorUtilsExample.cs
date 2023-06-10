namespace LearningArchive.Example
{
    public class EditorUtilsExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/002.MenuItem 复用", false, 2)]
        private static void MenuClicked()
        {
            EditorUtils.CallMenuItem("LearningArchive/Example/Util/001.拷贝文本到剪切板");
        }
#endif
    }
}
