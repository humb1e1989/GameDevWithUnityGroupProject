using System.Collections;
using UnityEngine;
//这个脚本给每个鬼都挂载
public class GhostEffectControler : MonoBehaviour
{
    [Tooltip("需要检测的碰撞物体标签")]
    [SerializeField] private string playerTag = "Player";
    [Tooltip("暂停持续时间（秒）")]
    [SerializeField] private float pausedTime = 5f;

    private bool isPaused=false;
    private Vector3 pausedPosition;

    private void Update()
    {
        if (isPaused)
        {
            //froze ghost in position
            transform.position = pausedPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name+ " 触发器检测到: " + other.gameObject.name + ", 标签: " + other.gameObject.tag);
        HandleCollision(other.gameObject);
    }
    private void HandleCollision(GameObject otherObject) 
    {
        // 检查是否与玩家碰撞
        if (otherObject.CompareTag(playerTag))
        {
            Debug.Log(gameObject.name+" 检测到碰撞玩家，执行暂停。");
            PausedGhost();
        }
    }
    //暂停敌人动作
    private void PausedGhost() 
    {
        if (!isPaused)
        {
            //get paused position
            pausedPosition = transform.position;
            //暂停
            isPaused = true;
            //等待暂停时间后重置运动
            StartCoroutine(UnlockAfterDelay());
        }
        if (isPaused) return;
    }
    // 协程：延迟后解锁
    System.Collections.IEnumerator UnlockAfterDelay()
    {
        yield return new WaitForSeconds(pausedTime);
        isPaused = false;
        Debug.Log(gameObject.name + " 结束暂停。");
    }
}
