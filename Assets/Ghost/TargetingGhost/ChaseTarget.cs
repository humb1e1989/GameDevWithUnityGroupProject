using UnityEngine;
using UnityEngine.AI;

public class ChaseTarget : MonoBehaviour
{
    public Transform target;  // 目标（玩家）
    private NavMeshAgent agent;
    private bool isFrozen = false;
    private float freezeTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // 获取 NavMeshAgent 组件
    }

    void Update()
    {
        if (isFrozen)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
            {
                Unfreeze(); // 解除冻结
            }
        }
        else if (target != null)
        {
            agent.SetDestination(target.position);  // 追踪玩家
        }
    }

    public void Freeze(float duration)
    {
        isFrozen = true;
        freezeTimer = duration;
        agent.isStopped = true;  // 停止移动
    }

    private void Unfreeze()
    {
        isFrozen = false;
        agent.isStopped = false;  // 重新开始移动
    }
}
