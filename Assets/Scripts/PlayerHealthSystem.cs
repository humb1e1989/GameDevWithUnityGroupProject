using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PlayerHealthSystem : MonoBehaviour
{
    [Header("生命设置")]
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int currentLives;
    [SerializeField] private float invincibilityDuration = 2f; // 受伤后的无敌时间

    [Header("UI 引用")]
    [SerializeField] private GameObject[] livesIcons; // 生命图标数组
    [SerializeField] private TextMeshProUGUI livesText; // 可选的文本显示
    [SerializeField] private Image damageFlashImage; // 屏幕受伤闪烁效果

    [Header("游戏结束设置")]
    [SerializeField] private GameObject gameOverCanvas; // 游戏结束画布

    // 设置生命图标数组的方法（由UI管理器调用）
    public void InitializeLifeIcons(GameObject[] icons)
    {
        livesIcons = icons;
        UpdateLivesUI();
    }

    // 设置生命文本的方法（由UI管理器调用）
    public void SetLivesText(TextMeshProUGUI text)
    {
        livesText = text;
        UpdateLivesUI();
    }

    // 设置伤害闪烁图像的方法（由UI管理器调用）
    public void SetDamageFlashImage(Image image)
    {
        damageFlashImage = image;
    }

    [Header("事件")]
    public UnityEvent onPlayerDamaged; // 玩家受伤时触发
    public UnityEvent onPlayerDeath; // 玩家死亡时触发
    public UnityEvent onExtraLifeGained; // 获得额外生命时触发

    private bool isInvincible = false;
    private Renderer playerRenderer; // 用于闪烁效果
    private Vector3 respawnPosition; // 玩家复活位置

    private void Awake()
    {
        playerRenderer = GetComponentInChildren<Renderer>();

        // 如果没有找到渲染器，尝试查找子对象中的渲染器
        if (playerRenderer == null)
        {
            Debug.LogWarning("未找到Renderer组件，闪烁效果将不可用");
        }

        if (damageFlashImage != null)
        {
            damageFlashImage.gameObject.SetActive(false);
        }
    }


    // 在PlayerHealthSystem.cs中添加
    void Update()
    {
        // 测试按键：按T键减少生命值
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("按下T键测试伤害");
            TakeDamage();
        }
    }




    private void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();

        // 保存初始重生点
        respawnPosition = transform.position;
    }



    // 更新UI显示当前生命值
    private void UpdateLivesUI()
    {
        // 更新生命图标
        if (livesIcons != null && livesIcons.Length > 0)
        {
            for (int i = 0; i < livesIcons.Length; i++)
            {
                livesIcons[i].SetActive(i < currentLives);
            }
        }

        // 更新生命文本（如果有）
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives.ToString();
        }
    }

    // 玩家受到伤害
    public void TakeDamage()
    {
        if (isInvincible)
            return;

        currentLives--;
        UpdateLivesUI();

        // 触发受伤事件
        onPlayerDamaged?.Invoke();

        // 播放受伤效果
        StartCoroutine(PlayDamageEffect());

        // 检查是否死亡
        if (currentLives <= 0)
        {
            Die();
        }
        else
        {
            // 短暂无敌
            StartCoroutine(BecomeInvincible());
        }
    }

    // 玩家死亡
    private void Die()
    {
        // 触发死亡事件
        onPlayerDeath?.Invoke();

        // 可以在这里添加死亡动画或粒子效果
        // 显示游戏结束画面
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            Debug.Log("游戏结束画面已显示");
        }
        else
        {
            Debug.LogError("游戏结束画面Canvas未设置！");
        }

        // 这里可以选择立即结束游戏或是等待一段时间后重生
        Debug.Log("玩家死亡");

        // 如果你想实现重生机制
        // Invoke("Respawn", respawnDelay);
    }

    // 获得额外生命
    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateLivesUI();

            // 触发获得生命事件
            onExtraLifeGained?.Invoke();

            Debug.Log("获得额外生命");
        }
    }

    // 设置新的重生点
    public void SetRespawnPoint(Vector3 position)
    {
        respawnPosition = position;
    }

    // 玩家重生
    private void Respawn()
    {
        // 将玩家传送到重生点
        transform.position = respawnPosition;

        // 重置状态，根据需要可能需要添加额外的重置逻辑
        GetComponent<Collider>().enabled = true;

        // 如果有角色控制器，可能需要重置它
        var controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = true;
        }
    }

    // 受伤后短暂无敌效果
    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;

        // 闪烁效果
        if (playerRenderer != null)
        {
            float endTime = Time.time + invincibilityDuration;
            bool visible = false;

            while (Time.time < endTime)
            {
                visible = !visible;
                playerRenderer.enabled = visible;
                yield return new WaitForSeconds(0.1f);
            }

            playerRenderer.enabled = true;
        }
        else
        {
            // 如果没有找到渲染器，只等待无敌时间
            yield return new WaitForSeconds(invincibilityDuration);
        }

        isInvincible = false;
    }

    // 受伤屏幕闪烁效果
    private IEnumerator PlayDamageEffect()
    {
        if (damageFlashImage != null)
        {
            damageFlashImage.gameObject.SetActive(true);
            Color flashColor = damageFlashImage.color;

            // 渐变消失效果
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 2)
            {
                flashColor.a = Mathf.Lerp(0.5f, 0, t);
                damageFlashImage.color = flashColor;
                yield return null;
            }

            damageFlashImage.gameObject.SetActive(false);
        }
    }

    // 用于调试的方法
    public void DebugLoseLife()
    {
        TakeDamage();
    }

    public void DebugAddLife()
    {
        AddLife();
    }
}