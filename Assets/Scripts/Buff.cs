using UnityEngine;
using System.Collections;  // 导入协程支持

public class Buff : MonoBehaviour
{
    public enum BuffType { IncreaseSize, DecreaseSize, EnableDash }
    public BuffType buffType;
    public float rotationSpeed = 30f; // 旋转速度

    private Vector3 originalSize; // 存储玩家的原始大小

    void Start()
    {
        // 存储玩家的原始大小和冲刺状态
        if (buffType == BuffType.IncreaseSize || buffType == BuffType.DecreaseSize)
        {
            originalSize = transform.localScale;
        }
    }

    void Update()
    {
        // 缓慢旋转
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                ApplyBuff(playerController);
                Destroy(gameObject); // Buff消失
            }
        }
    }

    void ApplyBuff(PlayerController playerController)
    {
        switch (buffType)
        {
            case BuffType.IncreaseSize:
                playerController.transform.localScale *= 3f; // 变为3倍大
                break;
            case BuffType.DecreaseSize:
                playerController.transform.localScale *= 0.5f; // 变为0.5倍大
                break;
            case BuffType.EnableDash:
                playerController.EnableDash(); // 激活冲刺功能
                break;
        }
    }

}
