using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUIManager : MonoBehaviour
{
    [Header("����UI����")]
    [SerializeField] private GameObject livesPanel;
    [SerializeField] private GameObject lifeIconPrefab;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private Image damageFlashImage;

    [Header("����")]
    [SerializeField] private int initialLives = 3;
    [SerializeField] private Color damageFlashColor = new Color(1f, 0f, 0f, 0.3f); // ��͸����ɫ

    private GameObject[] lifeIcons;
    private PlayerHealthSystem playerHealth;

    private void Start()
    {
        // ������ҵĽ���ϵͳ
        playerHealth = FindObjectOfType<PlayerHealthSystem>();

        if (playerHealth == null)
        {
            Debug.LogError("δ�ҵ�PlayerHealthSystem�������ȷ���������д����");
            return;
        }

        // ��ʼ��UI
        InitializeHealthUI();

        // ����������Ļ��˸��ɫ
        if (damageFlashImage != null)
        {
            damageFlashImage.color = damageFlashColor;
            damageFlashImage.gameObject.SetActive(false);
        }
    }

    private void InitializeHealthUI()
    {
        // ���ʹ��ͼ����ʾ����ֵ
        if (livesPanel != null && lifeIconPrefab != null)
        {
            // ����κ�����ͼ��
            foreach (Transform child in livesPanel.transform)
            {
                Destroy(child.gameObject);
            }

            // ��������ͼ��
            lifeIcons = new GameObject[initialLives];
            for (int i = 0; i < initialLives; i++)
            {
                GameObject lifeIcon = Instantiate(lifeIconPrefab, livesPanel.transform);
                lifeIcons[i] = lifeIcon;
            }

            // ��ͼ�����ô��ݸ���ҽ���ϵͳ
            playerHealth.InitializeLifeIcons(lifeIcons);
        }

        // ���ʹ���ı���ʾ����ֵ
        if (livesText != null)
        {
            livesText.text = "Lives: " + initialLives;
            playerHealth.SetLivesText(livesText);
        }

        // �����˺���˸ͼ��
        if (damageFlashImage != null)
        {
            playerHealth.SetDamageFlashImage(damageFlashImage);
        }
    }
}