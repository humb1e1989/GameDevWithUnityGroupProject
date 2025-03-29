using UnityEngine;
using Unity.Cinemachine;

public class FreeLookCameraCollision : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public Transform target;
    public float defaultDistance = 5f;
    public float minDistance = 1f;
    public float smoothTime = 0.2f;
    public LayerMask collisionLayer;

    private float[] originalOrbitRadii;
    private float[] currentOrbitRadii;
    private float[] velocities;

    void Start()
    {
        originalOrbitRadii = new float[freeLookCamera.m_Orbits.Length];
        currentOrbitRadii = new float[freeLookCamera.m_Orbits.Length];
        velocities = new float[freeLookCamera.m_Orbits.Length];

        for (int i = 0; i < freeLookCamera.m_Orbits.Length; i++)
        {
            originalOrbitRadii[i] = freeLookCamera.m_Orbits[i].m_Radius;
            currentOrbitRadii[i] = originalOrbitRadii[i];
        }
    }

    void LateUpdate()
    {
        for (int i = 0; i < freeLookCamera.m_Orbits.Length; i++)
        {
            Transform rigTransform = freeLookCamera.GetRig(i).transform;
            Vector3 direction = rigTransform.position - target.position;
            direction.Normalize();

            RaycastHit[] hits = Physics.RaycastAll(target.position, direction, originalOrbitRadii[i], collisionLayer);
            float closestHitDistance = originalOrbitRadii[i];

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.transform != target)
                {
                    closestHitDistance = Mathf.Min(closestHitDistance, hit.distance);
                }
            }

            currentOrbitRadii[i] = Mathf.Max(closestHitDistance, minDistance);
            currentOrbitRadii[i] = Mathf.SmoothDamp(currentOrbitRadii[i], currentOrbitRadii[i], ref velocities[i], smoothTime);

            freeLookCamera.m_Orbits[i].m_Radius = currentOrbitRadii[i];
        }
    }
}