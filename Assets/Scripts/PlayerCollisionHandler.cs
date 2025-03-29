using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private PlayerHealthSystem healthSystem;

    [Header("��ײ��ǩ")]
    [SerializeField] private string enemyTag = "Ghost"; // �޸�ΪGhost������Enemy
    [SerializeField] private string powerupTag = "Powerup";
    [SerializeField] private string extraLifeTag = "ExtraLife";

    [Header("��Ч")]
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip powerupSound;
    [SerializeField] private AudioClip extraLifeSound;

    private AudioSource audioSource;

    private void Start()
    {
        // ��ȡ����ϵͳ����
        healthSystem = GetComponent<PlayerHealthSystem>();
        if (healthSystem == null)
        {
            Debug.LogError("���ش���δ�ҵ�PlayerHealthSystem�������ȷ�������ӵ�ͬһ������");
        }
        else
        {
            Debug.Log("�ɹ��ҵ�����ϵͳ����");
        }

        // ��ȡ��ƵԴ
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null && (damageSound != null || powerupSound != null || extraLifeSound != null))
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.Log("�����AudioSource���");
        }
    }

    // ʹ��OnTriggerEnter����Ϊ���˵���ײ����ѡ��Is Trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("��������⵽: " + other.gameObject.name + ", ��ǩ: " + other.gameObject.tag);
        HandleCollision(other.gameObject);
    }

    // ����OnCollisionEnter�Է�ĳЩ����ʹ����ͨ��ײ
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("��ײ��⵽: " + collision.gameObject.name + ", ��ǩ: " + collision.gameObject.tag);
        HandleCollision(collision.gameObject);
    }

    private void HandleCollision(GameObject otherObject)
    {
        Debug.Log("HandleCollision�����ã�����" + otherObject.name + "����ǩ��" + otherObject.tag);
        Debug.Log("������Ѱ�ұ�ǩ��" + enemyTag);

        if (healthSystem == null)
        {
            Debug.LogError("δ�ҵ�����ϵͳ���ã�");
            return;
        }

        // ����Ƿ��������ײ
        if (otherObject.CompareTag(enemyTag))
        {
            Debug.Log("��⵽������ײ�����ڼ�������ֵ");
            // �������
            healthSystem.TakeDamage();

            // ����������Ч
            PlaySound(damageSound);
        }
        // ����Ƿ�����������ײ�����������ʹ��ҿ��ԳԹ�
        else if (otherObject.CompareTag(powerupTag))
        {
            Debug.Log("���������");
            // �����������߼�
            // �����������ҽ���ϵͳ���һ�������޵�ģʽ�����������ķ���

            // ������������Ч
            PlaySound(powerupSound);

            // ����������
            Destroy(otherObject);
        }
        // ����Ƿ������������ײ
        else if (otherObject.CompareTag(extraLifeTag))
        {
            Debug.Log("��ö�������");
            // ����һ������
            healthSystem.AddLife();

            // ���Ŷ���������Ч
            PlaySound(extraLifeSound);

            // ���ٶ���������Ʒ
            Destroy(otherObject);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
            Debug.Log("������Ч");
        }
    }

    // ���ڲ��Ե�Update���������������հ汾���Ƴ�
    private void Update()
    {
        // ���ԣ���T���ֶ���������
        if (Input.GetKeyDown(KeyCode.T) && healthSystem != null)
        {
            Debug.Log("��T�������˺�");
            healthSystem.TakeDamage();
        }
    }
}