using System.Collections;
using UnityEngine;
//这个脚本给每个鬼都挂载
public class GhostEffectControler : MonoBehaviour
{
    [Tooltip("需要检测的碰撞物体标签")]
    [SerializeField] private string playerTag = "Player";
    [Tooltip("暂停持续时间（秒）")]
    [SerializeField] private float pausedTime = 5f;

    private bool isPaused;

    private void Start()
    {
        isPaused = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("碰撞检测到: " + collision.gameObject.name + ", 标签: " + collision.gameObject.tag);
        HandleCollision(collision.gameObject);
    }
    private void HandleCollision(GameObject otherObject) 
    {
        // 检查是否与玩家碰撞
        if (otherObject.CompareTag(playerTag)&&(!isPaused))
        {
            Debug.Log("检测到碰撞玩家，执行暂停。");
            PausedGhost();
        }
    }
    //暂停敌人动作
    private IEnumerator PausedGhost() 
    { 
        //暂停
        isPaused=true;
        GetComponent<Collider>().enabled=false;
        //等待暂停时间
        yield return new WaitForSeconds(pausedTime);
        //重置
        isPaused=false;
        GetComponentInChildren<Collider>().enabled=true;
    }
}
