using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private PlayerHealthSystem healthSystem;

    [Header("碰撞标签")]
    [SerializeField] private string enemyTag = "Ghost"; // 修改为Ghost而不是Enemy
    [SerializeField] private string powerupTag = "Powerup";
    [SerializeField] private string extraLifeTag = "ExtraLife";

    [Header("音效")]
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip powerupSound;
    [SerializeField] private AudioClip extraLifeSound;

    private AudioSource audioSource;

    private void Start()
    {
        // 获取健康系统引用
        healthSystem = GetComponent<PlayerHealthSystem>();
        if (healthSystem == null)
        {
            Debug.LogError("严重错误：未找到PlayerHealthSystem组件，请确保它附加到同一对象上");
        }
        else
        {
            Debug.Log("成功找到健康系统引用");
        }

        // 获取音频源
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null && (damageSound != null || powerupSound != null || extraLifeSound != null))
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.Log("添加了AudioSource组件");
        }
    }

    // 使用OnTriggerEnter，因为敌人的碰撞器勾选了Is Trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("触发器检测到: " + other.gameObject.name + ", 标签: " + other.gameObject.tag);
        HandleCollision(other.gameObject);
    }

    // 保留OnCollisionEnter以防某些对象使用普通碰撞
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("碰撞检测到: " + collision.gameObject.name + ", 标签: " + collision.gameObject.tag);
        HandleCollision(collision.gameObject);
    }

    private void HandleCollision(GameObject otherObject)
    {
        Debug.Log("HandleCollision被调用，对象：" + otherObject.name + "，标签：" + otherObject.tag);
        Debug.Log("我们在寻找标签：" + enemyTag);

        if (healthSystem == null)
        {
            Debug.LogError("未找到健康系统引用！");
            return;
        }

        // 检查是否与敌人碰撞
        if (otherObject.CompareTag(enemyTag))
        {
            Debug.Log("检测到敌人碰撞，正在减少生命值");
            // 玩家受伤
            healthSystem.TakeDamage();

            // 播放受伤音效
            PlaySound(damageSound);
        }
        // 检查是否与能量豆碰撞（例如大力丸使玩家可以吃鬼）
        else if (otherObject.CompareTag(powerupTag))
        {
            Debug.Log("获得能量豆");
            // 处理能量豆逻辑
            // 这里可以向玩家健康系统添加一个启动无敌模式或特殊能力的方法

            // 播放能量豆音效
            PlaySound(powerupSound);

            // 销毁能量豆
            Destroy(otherObject);
        }
        // 检查是否与额外生命碰撞
        else if (otherObject.CompareTag(extraLifeTag))
        {
            Debug.Log("获得额外生命");
            // 增加一条生命
            healthSystem.AddLife();

            // 播放额外生命音效
            PlaySound(extraLifeSound);

            // 销毁额外生命物品
            Destroy(otherObject);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
            Debug.Log("播放音效");
        }
    }

    // 用于测试的Update方法，可以在最终版本中移除
    private void Update()
    {
        // 测试：按T键手动减少生命
        if (Input.GetKeyDown(KeyCode.T) && healthSystem != null)
        {
            Debug.Log("按T键测试伤害");
            healthSystem.TakeDamage();
        }
    }
}