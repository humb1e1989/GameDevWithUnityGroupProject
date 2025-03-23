using UnityEngine;

public class MinMapCameraManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform; //���λ����Ϣ
    [SerializeField] Transform minMapCameraTransform; //С��ͼ�������
    [SerializeField] Camera minMapCamera;

    [SerializeField] private LayerMask[] floorLayers;  // �����Ӧ��ͼ�㣨��˳����䣩
    [SerializeField] private float[] floorHeights;     // �����Y��߶ȷֽ�㣨�������У�


    public float cameraHeight = 20f; //С��ͼ����߶�
    public float cameraSize = 20f; //С��ͼ������ӳ���С

    private void Update()
    {
        
        UpdateCameraPosition();
        //UpdateCameraLayer();
    }

    private void UpdateCameraPosition() 
    {
        if (playerTransform == null)
        {
            Debug.Log("No player found!");
            return;
        }
        //������ƶ�ʵʱ����С��ͼ���λ��,ֻ����x��z��y�̶�Ϊ����߶�
        Vector3 newCameraPosition = new Vector3(playerTransform.position.x, cameraHeight, playerTransform.position.z);
        minMapCameraTransform.position = newCameraPosition;
        //��ֹ�����ת,�����Ƕ�Ϊxת90��
        minMapCameraTransform.rotation = Quaternion.Euler(90, 0, 0);
    }
    private void UpdateCameraLayer() 
    {
        if (minMapCamera == null) 
        {
            Debug.Log("No camera found!");
            return;
        }
        // �����ҵ�ǰ���ڵĲ�
        float playerY = playerTransform.position.y;
        int currentFloor = 0;

        // �����߶ȷֽ�㣬ȷ����ǰ��
        for (int i = 0; i < floorHeights.Length - 1; i++)
        {
            if (playerY >= floorHeights[i] && playerY < floorHeights[i + 1])
            {
                currentFloor = i;
                break;
            }
        }
        // �������������Ⱦ�㼶
        minMapCamera.cullingMask = floorLayers[currentFloor];
    }
}
