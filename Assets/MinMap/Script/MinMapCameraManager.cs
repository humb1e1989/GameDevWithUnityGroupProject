using UnityEngine;

public class MinMapCameraManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform; //���λ����Ϣ
    [SerializeField] Transform minMapCameraTransform; //С��ͼ�������
    [SerializeField] Camera minMapCamera;

    public float cameraHeight = 20f; //С��ͼ����߶�
    public float cameraSize = 20f; //С��ͼ������ӳ���С

    private void Update()
    {
        if (playerTransform == null) 
        {
            Debug.Log("No player found!");
        }
        //������ƶ�ʵʱ����С��ͼ���λ��,ֻ����x��z��y�̶�Ϊ����߶�
        Vector3 newCameraPosition = new Vector3(playerTransform.position.x, cameraHeight, playerTransform.position.z);
        minMapCameraTransform.position = newCameraPosition;
        //��ֹ�����ת,�����Ƕ�Ϊxת90��
        minMapCameraTransform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
