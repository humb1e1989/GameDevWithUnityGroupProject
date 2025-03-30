using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform player;      // ��Ҷ���
    public RectTransform arrow;  // ��ͷUI��RectTransform

    private void Update()
    {
        if (player == null || arrow == null) return;

        // ��ȡ���Y����ת�Ƕ�
        float angle = player.eulerAngles.y;

        // ���¼�ͷ��ת
        arrow.localEulerAngles = new Vector3(0, 0, -angle);
    }
}
