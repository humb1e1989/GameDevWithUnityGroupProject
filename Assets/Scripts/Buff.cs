using UnityEngine;
using System.Collections;  // 用于协程

public class Buff : MonoBehaviour
{
    public enum BuffType { IncreaseSize, DecreaseSize, EnableDash, FreezeEnemy }
    public BuffType buffType;
    public float rotationSpeed = 30f; // 旋转速度

    private Vector3 originalSize; // 存储玩家的原始大小

    void Start()
    {
        if (buffType == BuffType.IncreaseSize || buffType == BuffType.DecreaseSize)
        {
            originalSize = transform.localScale;
        }
    }

    void Update()
    {
        // 旋转 Buff 物品
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
                playerController.transform.localScale *= 3f;
                break;
            case BuffType.DecreaseSize:
                playerController.transform.localScale *= 0.5f;
                break;
            case BuffType.EnableDash:
                playerController.EnableDash();
                break;
            case BuffType.FreezeEnemy:
                FreezeEnemies(); // 冻结所有敌人
                break;
        }
    }

    void FreezeEnemies()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost"); // 查找所有 "Ghost" 标签的对象
        foreach (GameObject ghost in ghosts)
        {
            ChaseTarget chaseTarget = ghost.GetComponent<ChaseTarget>(); // 获取 ChaseTarget 组件
            if (chaseTarget != null)
            {
                chaseTarget.Freeze(15f); // 让鬼冻结15秒
            }
        }
    }
}
