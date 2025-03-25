using UnityEngine;

public class GhostLayer : MonoBehaviour
{
    //[SerializeField] private GameObject Gobject;
    private float detectionDistance = 10f; // ������
    //private LayerMask targetLayers; // Ҫ����ͼ��

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position;//�ӵײ���������
        Vector3 direction = Vector3.down;
        if (Physics.Raycast(origin, direction, out RaycastHit hit, detectionDistance)) 
        { 
            LayerMask dectedLayer = hit.collider.gameObject.layer;
            if (gameObject.layer != dectedLayer) 
            {
                gameObject.layer = dectedLayer;
                Debug.Log("Layer change to " + dectedLayer);
            }
        }
    }
}
