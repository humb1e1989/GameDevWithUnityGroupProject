using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PlayerHealthSystem : MonoBehaviour
{
    [Header("��������")]
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int currentLives;
    [SerializeField] private float invincibilityDuration = 2f; // ���˺���޵�ʱ��

    [Header("UI ����")]
    [SerializeField] private GameObject[] livesIcons; // ����ͼ������
    [SerializeField] private TextMeshProUGUI livesText; // ��ѡ���ı���ʾ
    [SerializeField] private Image damageFlashImage; // ��Ļ������˸Ч��

    [Header("��Ϸ��������")]
    [SerializeField] private GameObject gameOverCanvas; // ��Ϸ��������

    // ��������ͼ������ķ�������UI���������ã�
    public void InitializeLifeIcons(GameObject[] icons)
    {
        livesIcons = icons;
        UpdateLivesUI();
    }

    // ���������ı��ķ�������UI���������ã�
    public void SetLivesText(TextMeshProUGUI text)
    {
        livesText = text;
        UpdateLivesUI();
    }

    // �����˺���˸ͼ��ķ�������UI���������ã�
    public void SetDamageFlashImage(Image image)
    {
        damageFlashImage = image;
    }

    [Header("�¼�")]
    public UnityEvent onPlayerDamaged; // �������ʱ����
    public UnityEvent onPlayerDeath; // �������ʱ����
    public UnityEvent onExtraLifeGained; // ��ö�������ʱ����

    private bool isInvincible = false;
    private Renderer playerRenderer; // ������˸Ч��
    private Vector3 respawnPosition; // ��Ҹ���λ��

    private void Awake()
    {
        playerRenderer = GetComponentInChildren<Renderer>();

        // ���û���ҵ���Ⱦ�������Բ����Ӷ����е���Ⱦ��
        if (playerRenderer == null)
        {
            Debug.LogWarning("δ�ҵ�Renderer�������˸Ч����������");
        }

        if (damageFlashImage != null)
        {
            damageFlashImage.gameObject.SetActive(false);
        }
    }


    // ��PlayerHealthSystem.cs�����
    void Update()
    {
        // ���԰�������T����������ֵ
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("����T�������˺�");
            TakeDamage();
        }
    }




    private void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();

        // �����ʼ������
        respawnPosition = transform.position;
    }



    // ����UI��ʾ��ǰ����ֵ
    private void UpdateLivesUI()
    {
        // ��������ͼ��
        if (livesIcons != null && livesIcons.Length > 0)
        {
            for (int i = 0; i < livesIcons.Length; i++)
            {
                livesIcons[i].SetActive(i < currentLives);
            }
        }

        // ���������ı�������У�
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives.ToString();
        }
    }

    // ����ܵ��˺�
    public void TakeDamage()
    {
        if (isInvincible)
            return;

        currentLives--;
        UpdateLivesUI();

        // ���������¼�
        onPlayerDamaged?.Invoke();

        // ��������Ч��
        StartCoroutine(PlayDamageEffect());

        // ����Ƿ�����
        if (currentLives <= 0)
        {
            Die();
        }
        else
        {
            // �����޵�
            StartCoroutine(BecomeInvincible());
        }
    }

    // �������
    private void Die()
    {
        // ���������¼�
        onPlayerDeath?.Invoke();

        // ���������������������������Ч��
        // ��ʾ��Ϸ��������
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            Debug.Log("��Ϸ������������ʾ");
        }
        else
        {
            Debug.LogError("��Ϸ��������Canvasδ���ã�");
        }

        // �������ѡ������������Ϸ���ǵȴ�һ��ʱ�������
        Debug.Log("�������");

        // �������ʵ����������
        // Invoke("Respawn", respawnDelay);
    }

    // ��ö�������
    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateLivesUI();

            // ������������¼�
            onExtraLifeGained?.Invoke();

            Debug.Log("��ö�������");
        }
    }

    // �����µ�������
    public void SetRespawnPoint(Vector3 position)
    {
        respawnPosition = position;
    }

    // �������
    private void Respawn()
    {
        // ����Ҵ��͵�������
        transform.position = respawnPosition;

        // ����״̬��������Ҫ������Ҫ��Ӷ���������߼�
        GetComponent<Collider>().enabled = true;

        // ����н�ɫ��������������Ҫ������
        var controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = true;
        }
    }

    // ���˺�����޵�Ч��
    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;

        // ��˸Ч��
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
            // ���û���ҵ���Ⱦ����ֻ�ȴ��޵�ʱ��
            yield return new WaitForSeconds(invincibilityDuration);
        }

        isInvincible = false;
    }

    // ������Ļ��˸Ч��
    private IEnumerator PlayDamageEffect()
    {
        if (damageFlashImage != null)
        {
            damageFlashImage.gameObject.SetActive(true);
            Color flashColor = damageFlashImage.color;

            // ������ʧЧ��
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 2)
            {
                flashColor.a = Mathf.Lerp(0.5f, 0, t);
                damageFlashImage.color = flashColor;
                yield return null;
            }

            damageFlashImage.gameObject.SetActive(false);
        }
    }

    // ���ڵ��Եķ���
    public void DebugLoseLife()
    {
        TakeDamage();
    }

    public void DebugAddLife()
    {
        AddLife();
    }
}