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
<<<<<<< Updated upstream
                playerController.transform.localScale *= 3f; // 变为3倍大
                break;
            case BuffType.DecreaseSize:
                playerController.transform.localScale *= 0.5f; // 变为0.5倍大
                break;
            case BuffType.EnableDash:
                playerController.EnableDash(); // 激活冲刺功能
=======
                Debug.Log("变大");
                playerController.ChangeSize(playerController.transform.localScale * 3f, 15f, "IncreaseSize"); // 变大并持续15秒
                break;
            case BuffType.DecreaseSize:
                Debug.Log("变小");
                playerController.ChangeSize(playerController.transform.localScale * 0.5f, 15f, "DecreaseSize"); // 变小并持续15秒
                break;
            case BuffType.EnableDash:
                Debug.Log("加速");
                playerController.EnableDash(15f); // 启用冲刺并持续15秒
                break;
            case BuffType.FreezeEnemy:
                FreezeEnemies(); // 冻结所有敌人
                break;
            case BuffType.TransparentWall:
                MakeWallsTransparent(); // 让墙体变透明
                break;
            case BuffType.TeleportToCoin:
                TeleportPlayerNearRandomCoin(playerController.gameObject); // 传送到随机 Coin 旁边
>>>>>>> Stashed changes
                break;
        }
    }

}
