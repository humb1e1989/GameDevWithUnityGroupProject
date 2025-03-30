using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform player;      // 玩家对象
    public RectTransform arrow;  // 箭头UI的RectTransform

    private void Update()
    {
        if (player == null || arrow == null) return;

        // 获取玩家Y轴旋转角度
        float angle = player.eulerAngles.y;

        // 更新箭头旋转
        arrow.localEulerAngles = new Vector3(0, 0, -angle);
    }
}
