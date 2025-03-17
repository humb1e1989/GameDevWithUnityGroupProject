using UnityEngine;
using UnityEngine.AI;

public class ChaseTarget : MonoBehaviour
{
    public Transform target;  // 目标（玩家）
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // 获取 NavMeshAgent 组件
    }

    void Update()
    {
        if (target != null)
        {
            // 设定敌人目标位置，忽略障碍物
            agent.SetDestination(target.position);
        }
    }
}
