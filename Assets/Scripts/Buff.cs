using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public enum BuffType { IncreaseSize, DecreaseSize, EnableDash, FreezeEnemy, TransparentWall, TeleportToCoin }
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
                Debug.Log("变大");
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
            case BuffType.TransparentWall:
                MakeWallsTransparent(); // 让墙体变透明
                break;
            case BuffType.TeleportToCoin:
                TeleportPlayerNearRandomCoin(playerController.gameObject); // 传送到随机 Coin 旁边
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

    void MakeWallsTransparent()
    {
        // 查找所有墙体对象 (Maze_01, Maze_02)
        GameObject maze1 = GameObject.Find("Maze_01");
        GameObject maze2 = GameObject.Find("Maze_02");

        GameObject guide = GameObject.Find("GuidePath");

        // 查找子物体 GuidePath
        GameObject guidePath = guide?.transform.Find("Guide")?.gameObject;

        // 如果墙体存在，改变它们的透明度
        if (maze1 != null)
        {
            SetTransparency(maze1, 0.3f); // 设置透明度为 50%
        }

        if (maze2 != null)
        {
            SetTransparency(maze2, 0.3f); // 设置透明度为 50%
        }

        Debug.Log(guidePath);
        if (guidePath != null)
        {
            guidePath.SetActive(true); // 显示路径
        }
    }

    void SetTransparency(GameObject obj, float alpha)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material mat = renderer.material;

            // 设置为透明模式（适用于Lit Shader）
            mat.SetFloat("_Surface", 1); // 设置为透明（_Surface: 1 = Transparent）
            mat.SetFloat("_Blend", 1);    // 设置为透明混合模式
            mat.SetInt("_ZWrite", 0);     // 禁用深度写入
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);  // 设置源混合模式为SrcAlpha
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);  // 设置目标混合模式为OneMinusSrcAlpha
            mat.SetInt("_ZTest", (int)UnityEngine.Rendering.CompareFunction.LessEqual);  // 启用深度测试

            // 修改透明度
            Color color = mat.GetColor("_BaseColor");  // 获取原始颜色
            color.a = alpha;  // 设置透明度
            mat.SetColor("_BaseColor", color);  // 更新颜色

            // 设置渲染队列，透明物体通常设置为3000以上
            mat.renderQueue = 3000;

            Debug.Log($"Material {renderer.name} alpha set to: {alpha}");
        }
    }

    void TeleportPlayerNearRandomCoin(GameObject player)
    {
        // 找到所有硬币
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        // 如果没有找到硬币，跳过传送
        if (coins == null || coins.Length == 0)
        {
            Debug.LogWarning("No coins found, skipping teleport.");
            return;
        }

        // 随机选择一个硬币
        int randomIndex = Random.Range(0, coins.Length);
        GameObject targetCoin = coins[randomIndex];

        if (targetCoin != null)
        {
            // 计算金币附近的随机位置
            Vector3 randomOffset = new Vector3(
                Random.Range(-2f, 2f), // X 轴偏移
                0, // Y 轴不变
                Random.Range(-2f, 2f)  // Z 轴偏移
            );

            // 将玩家传送到金币附近的位置
            player.transform.position = targetCoin.transform.position + randomOffset;
            Debug.Log($"Player teleported near coin at position: {targetCoin.transform.position} with offset: {randomOffset}");
        }
    }
}