using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeToBlack : MonoBehaviour
{
    public Image blackScreenImage;  // 黑色遮罩的 Image 组件

    private void Start()
    {
        Debug.Log("透明");
        // 确保黑屏一开始是透明的
        blackScreenImage.color = new Color(0, 0, 0, 0);  // 透明
    }

    public void StartFadeToBlack()
    {
        Debug.Log("渐变开始");
        // 开始渐变黑屏
        StartCoroutine(FadeInBlackScreen());
    }

    private IEnumerator FadeInBlackScreen()
    {
        float duration = 2f;  // 渐变时间（秒）
        float timer = 0f;
        Color startColor = blackScreenImage.color; // 初始颜色（透明）
        Color endColor = new Color(0, 0, 0, 1);    // 目标颜色（黑色）

        // 渐变过程
        while (timer < duration)
        {
            timer += Time.deltaTime;
            blackScreenImage.color = Color.Lerp(startColor, endColor, timer / duration);
            yield return null;
        }

        // 确保最终是完全黑色
        blackScreenImage.color = endColor;
    }
}
