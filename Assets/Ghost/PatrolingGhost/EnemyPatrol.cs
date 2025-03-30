using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("巡逻设置")]
    public Vector3 patrolOffset = new Vector3(5f, 0f, 5f);  // 相对于初始位置的偏移量
    public float speed = 1.5f;
    public float rotationSpeed = 5.0f;

    private Vector3 startPosition;  // 记录初始位置
    private Vector3 targetPosition; // 计算出的目标位置
    private bool movingToOffset = true;

    void Start()
    {
        startPosition = transform.position;  // 记录初始位置
        targetPosition = startPosition + patrolOffset;  // 计算目标位置
    }

    void Update()
    {
        // 移动逻辑
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // 转向逻辑
        Vector3 direction = targetPosition - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // 到达检测
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (movingToOffset)
            {
                targetPosition = startPosition;  // 返回起始点
            }
            else
            {
                targetPosition = startPosition + patrolOffset;  // 前往偏移点
            }
            movingToOffset = !movingToOffset;
        }
    }

    // 在Scene视图中绘制巡逻路径（方便调试）
    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPosition, startPosition + patrolOffset);
            Gizmos.DrawSphere(startPosition, 0.2f);
            Gizmos.DrawSphere(startPosition + patrolOffset, 0.2f);
        }
    }
}