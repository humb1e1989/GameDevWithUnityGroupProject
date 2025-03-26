using UnityEngine;

public class GhostLayer : MonoBehaviour
{
    //[SerializeField] private GameObject Gobject;
    private float detectionDistance = 10f; // 检测距离
    //private LayerMask targetLayers; // 要检测的图层

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position;//从底部发射射线
        Vector3 direction = Vector3.down;
        if (Physics.Raycast(origin, direction, out RaycastHit hit, detectionDistance)) 
        { 
            LayerMask dectedLayer = hit.collider.gameObject.layer;
            if (gameObject.layer != dectedLayer) 
            {
                gameObject.layer = dectedLayer;
                ChangeChildrenLayer(gameObject.transform, dectedLayer);
                Debug.Log("Layer change to " + dectedLayer);
            }
        }
    }

    private void ChangeChildrenLayer(Transform transform, LayerMask targetLayer) 
    {
        
        // 一次性获取所有子对象Transform（包括嵌套子对象和未激活的）
        Transform[] allTransforms = GetComponentsInChildren<Transform>(true);

        // 遍历更新
        foreach (Transform t in allTransforms)
        {
            t.gameObject.layer = targetLayer;
        }

        Debug.Log($"已更新 {allTransforms.Length} 个对象的层级为 {targetLayer}");
    }
}
