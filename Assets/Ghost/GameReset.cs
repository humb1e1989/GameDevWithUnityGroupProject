using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour
{
    public Transform player;  // 玩家
    public Transform enemy;   // 敌人
    public FadeToBlack fadeToBlack;  // 黑屏渐变组件

    private Vector3 playerStartPosition;
    private Vector3 enemyStartPosition;

    private void Start()
    {
        // 记录玩家和敌人初始位置
        playerStartPosition = player.position;
        enemyStartPosition = enemy.position;
    }

    public void ResetGame()
    {
        StartCoroutine(ResetRoutine());
    }

    private IEnumerator ResetRoutine()
    {
        // 等待音效播放完毕
        yield return new WaitForSeconds(2f);  // 2秒后重置（时间可根据音效长度调整）

        // 渐变淡出黑屏
        if (fadeToBlack != null)
        {
            fadeToBlack.StartFadeOut();
        }

        // 重置玩家和敌人的位置
        player.position = playerStartPosition;
        enemy.position = enemyStartPosition;

        Debug.Log("游戏已重置");
    }
}
