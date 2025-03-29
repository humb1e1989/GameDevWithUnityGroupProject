using System.Collections;
using UnityEngine;
//����ű���ÿ��������
public class GhostEffectControler : MonoBehaviour
{
    [Tooltip("��Ҫ������ײ�����ǩ")]
    [SerializeField] private string playerTag = "Player";
    [Tooltip("��ͣ����ʱ�䣨�룩")]
    [SerializeField] private float pausedTime = 5f;

    private bool isPaused=false;
    private Vector3 pausedPosition;
    //private Rigidbody ghostRb;

    private void Start()
    {
        //ghostRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isPaused)
        {
            //froze ghost in position
            transform.position = pausedPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name+ " ��������⵽: " + other.gameObject.name + ", ��ǩ: " + other.gameObject.tag);
        HandleCollision(other.gameObject);
    }
    private void HandleCollision(GameObject otherObject) 
    {
        // ����Ƿ��������ײ
        if (otherObject.CompareTag(playerTag))
        {
            Debug.Log(gameObject.name+" ��⵽��ײ��ң�ִ����ͣ��");
            PausedGhost();
        }
    }
    //��ͣ���˶���
    private IEnumerator PausedGhost() 
    {
        if (!isPaused)
        {
            //get paused position
            pausedPosition = transform.position;
            //��ͣ
            isPaused = true;
            //�ȴ���ͣʱ��
            yield return new WaitForSeconds(pausedTime);
            //����
            isPaused = false;
            Debug.Log(gameObject.name+" ������ͣ��");
        }
    }
}
