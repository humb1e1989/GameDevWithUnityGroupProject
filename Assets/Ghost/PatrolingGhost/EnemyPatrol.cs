using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Vector3 pointA = new Vector3(1, 0, 0);  // 起始点 A
    public Vector3 pointB = new Vector3(0, 0, 0);  // 终点 B
    public float speed = 1.5f;  // 控制移动速度
    public float rotationSpeed = 5.0f;  // 旋转速度，决定转头的平滑度
    private Vector3 currentTarget;  // 当前目标点
    private bool movingToB = true;  // 用于判断当前是否在向B点移动

    void Start()
    {
        // 初始化当前目标为 pointA
        currentTarget = pointA;
    }

    void Update()
    {
        // 计算每帧的移动量
        float step = speed * Time.deltaTime;

        // 移动敌人
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);

        // 计算目标方向
        Vector3 targetDirection = currentTarget - transform.position;

        // 平滑地转向目标方向
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // 检查敌人是否到达目标点
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            // 到达目标后切换目标
            if (movingToB)
            {
                currentTarget = pointB;  // 设置为B点
            }
            else
            {
                currentTarget = pointA;  // 设置为A点
            }
            movingToB = !movingToB;  // 切换方向
        }
    }

    // 当触发器与物体碰撞时调用
    void OnTriggerEnter(Collider other)
    {
        // 如果触发的是 Player
        if (other.gameObject.CompareTag("Player"))
        {
            // 打印到控制台
            Debug.Log("Enemy triggered by Player!");
        }
    }
}
