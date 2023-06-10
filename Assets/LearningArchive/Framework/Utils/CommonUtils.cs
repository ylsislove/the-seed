using UnityEngine;

namespace LearningArchive
{
    public partial class CommonUtils
    {
        public static void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }
    }
}