namespace LearningArchive.Example
{
    public class CommonUtilsExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/001.拷贝文本到剪切板", false, 1)]
#endif
        private static void MenuClicked()
        {
            CommonUtils.CopyText("要复制的文本");
        }
    }
}
