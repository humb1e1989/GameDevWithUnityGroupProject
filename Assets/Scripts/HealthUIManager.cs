using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUIManager : MonoBehaviour
{
    [Header("生命UI引用")]
    [SerializeField] private GameObject livesPanel;
    [SerializeField] private GameObject lifeIconPrefab;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private Image damageFlashImage;

    [Header("设置")]
    [SerializeField] private int initialLives = 3;
    [SerializeField] private Color damageFlashColor = new Color(1f, 0f, 0f, 0.3f); // 半透明红色

    private GameObject[] lifeIcons;
    private PlayerHealthSystem playerHealth;

    private void Start()
    {
        // 查找玩家的健康系统
        playerHealth = FindObjectOfType<PlayerHealthSystem>();

        if (playerHealth == null)
        {
            Debug.LogError("未找到PlayerHealthSystem组件，请确保场景中有此组件");
            return;
        }

        // 初始化UI
        InitializeHealthUI();

        // 设置受伤屏幕闪烁颜色
        if (damageFlashImage != null)
        {
            damageFlashImage.color = damageFlashColor;
            damageFlashImage.gameObject.SetActive(false);
        }
    }

    private void InitializeHealthUI()
    {
        // 如果使用图标显示生命值
        if (livesPanel != null && lifeIconPrefab != null)
        {
            // 清除任何现有图标
            foreach (Transform child in livesPanel.transform)
            {
                Destroy(child.gameObject);
            }

            // 创建生命图标
            lifeIcons = new GameObject[initialLives];
            for (int i = 0; i < initialLives; i++)
            {
                GameObject lifeIcon = Instantiate(lifeIconPrefab, livesPanel.transform);
                lifeIcons[i] = lifeIcon;
            }

            // 将图标引用传递给玩家健康系统
            playerHealth.InitializeLifeIcons(lifeIcons);
        }

        // 如果使用文本显示生命值
        if (livesText != null)
        {
            livesText.text = "Lives: " + initialLives;
            playerHealth.SetLivesText(livesText);
        }

        // 设置伤害闪烁图像
        if (damageFlashImage != null)
        {
            playerHealth.SetDamageFlashImage(damageFlashImage);
        }
    }
}