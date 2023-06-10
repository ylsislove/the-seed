using UnityEngine;

namespace LearningArchive.Example
{
    public class MathUtilsExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/006.概率函数和随机函数", false, 6)]
#endif
        private static void MenuClicked()
        {
            Debug.Log(MathUtils.Percent(50));

            var randomAge = MathUtils.GetRandomValueFrom(new int[] { 1, 2, 3 });
            Debug.Log(randomAge);

            var randomAge2 = MathUtils.GetRandomValueFrom("asdasd", "123123");
            Debug.Log(randomAge2);
        }
    }
}
