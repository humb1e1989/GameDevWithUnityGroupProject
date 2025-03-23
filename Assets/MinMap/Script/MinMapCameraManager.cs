using UnityEngine;

public class MinMapCameraManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform; //玩家位置信息
    [SerializeField] Transform minMapCameraTransform; //小地图相机对象
    [SerializeField] Camera minMapCamera;

    [SerializeField] private LayerMask[] floorLayers;  // 各层对应的图层（按顺序填充）
    [SerializeField] private float[] floorHeights;     // 各层的Y轴高度分界点（升序排列）


    public float cameraHeight = 20f; //小地图相机高度
    public float cameraSize = 20f; //小地图相机的视场大小

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
        //随玩家移动实时更新小地图相机位置,只更新x和z，y固定为相机高度
        Vector3 newCameraPosition = new Vector3(playerTransform.position.x, cameraHeight, playerTransform.position.z);
        minMapCameraTransform.position = newCameraPosition;
        //防止相机旋转,锁定角度为x转90度
        minMapCameraTransform.rotation = Quaternion.Euler(90, 0, 0);
    }
    private void UpdateCameraLayer() 
    {
        if (minMapCamera == null) 
        {
            Debug.Log("No camera found!");
            return;
        }
        // 检测玩家当前所在的层
        float playerY = playerTransform.position.y;
        int currentFloor = 0;

        // 遍历高度分界点，确定当前层
        for (int i = 0; i < floorHeights.Length - 1; i++)
        {
            if (playerY >= floorHeights[i] && playerY < floorHeights[i + 1])
            {
                currentFloor = i;
                break;
            }
        }
        // 更新摄像机的渲染层级
        minMapCamera.cullingMask = floorLayers[currentFloor];
    }
}
