using UnityEditor;
using UnityEngine;

public class EnemyAudioTrigger : MonoBehaviour
{
    public Transform player;  // 你的玩家对象
    public float triggerDistance = 50f;  // 音效触发的最大距离
    public float stopDistance = 5f;  // 当敌人离玩家小于这个距离时停止音效并播放新音效
    public AudioClip[] audioClips;  // 音效数组，存储多个音效
    private AudioSource audioSource;  // 音效播放组件
    private int currentClipIndex = 0;  // 当前播放的音效索引
    private bool hasPlayed = false;  // 标记是否已经播放过新的音效

    // 通过 Inspector 关联
    public FadeToBlack fadeToBlack;  // 黑屏渐变脚本

    private void Start()
    {
        // 获取或添加 AudioSource 组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 设置音效，但不立即播放
        if (audioClips.Length > 0)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.loop = false;  // 设置音效不循环播放
        }
    }

    private void Update()
    {
        // 计算玩家与敌人之间的距离
        float distance = Vector3.Distance(transform.position, player.position);

        // 如果距离小于触发距离
        if (distance <= triggerDistance)
        {
            // 计算音量，使用反比例关系，距离越近音量越大
            float volume = Mathf.Lerp(0, 1, 1 - (distance / triggerDistance));
            audioSource.volume = volume;

            // 播放音效（如果没有播放）但不立即播放
            if (!audioSource.isPlaying && !hasPlayed)
            {
                audioSource.Play();
            }
        }

        // 如果距离小于 stopDistance，切换音效并只播放一次
        if (distance <= stopDistance && !hasPlayed)
        {
            // 停止当前音效
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            // 切换到下一个音效
            currentClipIndex = (currentClipIndex + 1) % audioClips.Length;

            // 播放下一段音效
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();

            // 播放第二段音效时触发渐变黑屏
            if (fadeToBlack != null)
            {
                Debug.Log("黑屏触发");
                fadeToBlack.StartFadeToBlack();  // 开始渐变黑屏
            }

            // 标记音效已播放
            hasPlayed = true;
        }

        // 如果玩家离敌人超出 stopDistance，重置音效播放状态
        if (distance > stopDistance)
        {
            hasPlayed = false;
        }
    }
}
