using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;
    [SerializeField] private GameObject gameFinishCanvas;

    public static int score = 0; // 静态分数变量

    private float containerInitPosition;
    private float moveAmount;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
        gameFinishCanvas.SetActive(false);
    }

    public void UpdateScore(int newScore)
    {
        // 设置分数到待更新的文本UI
        toUpdate.SetText($"{newScore}");
        // 触发本地移动动画
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
        // 启动协程
        StartCoroutine(ResetCoinContainer(newScore));

        if (newScore >= 20)
        {
            GameFinish();
            Debug.Log("游戏胜利");
            newScore = 0;
            score = 0;
        }
    }

    private IEnumerator ResetCoinContainer(int newScore)
    {
        // 等待指定时间
        yield return new WaitForSeconds(duration);
        // 更新原始分数
        current.SetText($"{newScore}");
        // 重置 coinTextContainer 的 y 本地位置
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
    }

    private void GameFinish()
    {
        gameFinishCanvas.SetActive(true); // 显示胜利界面
        Time.timeScale = 0f; // 暂停游戏
        Debug.Log("游戏胜利，已暂停！");
    }
}