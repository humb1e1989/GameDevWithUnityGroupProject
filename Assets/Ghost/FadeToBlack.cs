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

    // 开始渐变黑屏
    public void StartFadeToBlack()
    {
        Debug.Log("渐变黑屏开始");
        StartCoroutine(FadeInBlackScreen());
    }

    // 开始渐变淡出黑屏
    public void StartFadeOut()
    {
        Debug.Log("渐变消失开始");
        StartCoroutine(FadeOutBlackScreen());
    }

    private IEnumerator FadeInBlackScreen()
    {
        float duration = 2f;  // 渐变时间（秒）
        float timer = 0f;
        Color startColor = blackScreenImage.color; // 初始颜色（透明）
        Color endColor = new Color(0, 0, 0, 1);    // 目标颜色（黑色）

        while (timer < duration)
        {
            timer += Time.deltaTime;
            blackScreenImage.color = Color.Lerp(startColor, endColor, timer / duration);
            yield return null;
        }

        blackScreenImage.color = endColor; // 确保完全变黑
    }

    private IEnumerator FadeOutBlackScreen()
    {
        float duration = 2f;  // 渐变时间（秒）
        float timer = 0f;
        Color startColor = blackScreenImage.color; // 初始颜色（黑色）
        Color endColor = new Color(0, 0, 0, 0);    // 目标颜色（透明）

        while (timer < duration)
        {
            timer += Time.deltaTime;
            blackScreenImage.color = Color.Lerp(startColor, endColor, timer / duration);
            yield return null;
        }

        blackScreenImage.color = endColor; // 确保完全透明
    }
}
