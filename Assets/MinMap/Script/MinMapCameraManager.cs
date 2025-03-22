using UnityEngine;

public class MinMapCameraManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform; //玩家位置信息
    [SerializeField] Transform minMapCameraTransform; //小地图相机对象
    [SerializeField] Camera minMapCamera;

    public float cameraHeight = 20f; //小地图相机高度
    public float cameraSize = 20f; //小地图相机的视场大小

    private void Update()
    {
        if (playerTransform == null) 
        {
            Debug.Log("No player found!");
        }
        //随玩家移动实时更新小地图相机位置,只更新x和z，y固定为相机高度
        Vector3 newCameraPosition = new Vector3(playerTransform.position.x, cameraHeight, playerTransform.position.z);
        minMapCameraTransform.position = newCameraPosition;
        //防止相机旋转,锁定角度为x转90度
        minMapCameraTransform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
