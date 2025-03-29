using UnityEngine;

// �˽ű���������Ϸ��ͣʱ��������������
public class UnscaledAnimation : MonoBehaviour
{
    [SerializeField] private Animator[] animatorsToControl;

    private float[] defaultAnimatorSpeeds;

    private void Awake()
    {
        // �ҵ�������Ҫ���Ƶ�Animator
        if (animatorsToControl == null || animatorsToControl.Length == 0)
        {
            // ���û���ֶ����ã����ȡ��ǰ�������Ӷ����ϵ�����Animator
            animatorsToControl = GetComponentsInChildren<Animator>(true);
        }

        // ����ԭʼ�ٶ�
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
        // ����Ϸ��ͣʱ��ʹ��unscaledDeltaTime���������ٶ�
        if (Time.timeScale < 0.01f)
        {
            for (int i = 0; i < animatorsToControl.Length; i++)
            {
                if (animatorsToControl[i] != null)
                {
                    // ��ʹ�÷�����ʱ��ʱ����Ҫ�ֶ������ٶ�
                    animatorsToControl[i].updateMode = AnimatorUpdateMode.UnscaledTime;
                }
            }
        }
        else
        {
            // ����Ϸ�ָ�ʱ���������ָ�ΪĬ������
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