using UnityEngine;

// 此脚本用于在游戏暂停时允许动画继续播放
public class UnscaledAnimation : MonoBehaviour
{
    [SerializeField] private Animator[] animatorsToControl;

    private float[] defaultAnimatorSpeeds;

    private void Awake()
    {
        // 找到所有需要控制的Animator
        if (animatorsToControl == null || animatorsToControl.Length == 0)
        {
            // 如果没有手动设置，则获取当前对象及其子对象上的所有Animator
            animatorsToControl = GetComponentsInChildren<Animator>(true);
        }

        // 保存原始速度
        defaultAnimatorSpeeds = new float[animatorsToControl.Length];
        for (int i = 0; i < animatorsToControl.Length; i++)
        {
            if (animatorsToControl[i] != null)
            {
                defaultAnimatorSpeeds[i] = animatorsToControl[i].speed;
            }
        }
    }

    private void Update()
    {
        // 当游戏暂停时，使用unscaledDeltaTime调整动画速度
        if (Time.timeScale < 0.01f)
        {
            for (int i = 0; i < animatorsToControl.Length; i++)
            {
                if (animatorsToControl[i] != null)
                {
                    // 当使用非缩放时间时，需要手动调整速度
                    animatorsToControl[i].updateMode = AnimatorUpdateMode.UnscaledTime;
                }
            }
        }
        else
        {
            // 当游戏恢复时，将动画恢复为默认设置
            for (int i = 0; i < animatorsToControl.Length; i++)
            {
                if (animatorsToControl[i] != null)
                {
                    animatorsToControl[i].updateMode = AnimatorUpdateMode.Normal;
                    animatorsToControl[i].speed = defaultAnimatorSpeeds[i];
                }
            }
        }
    }
}