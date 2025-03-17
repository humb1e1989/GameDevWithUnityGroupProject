using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public FadeToBlack fadeToBlackScript;  // 引用FadeToBlack脚本
    public AudioClip soundClip;            // 要播放的声音文件（拖拽到 Inspector）

    // 当Collider进入触发区时
    private void OnTriggerEnter(Collider other)
    {
        // 确保触发的是Player
        if (other.CompareTag("Player"))
        {
            // 打印调试信息
            Debug.Log("与玩家接触，执行渐变黑屏");

            // 播放声音
            if (soundClip != null)
            {
                AudioSource.PlayClipAtPoint(soundClip, transform.position);
            }

            // 调用FadeToBlack中的渐变黑屏方法
            if (fadeToBlackScript != null)
            {
                fadeToBlackScript.StartFadeToBlack();
            }
        }
    }
}
