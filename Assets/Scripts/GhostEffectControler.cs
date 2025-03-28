using System.Collections;
using UnityEngine;
//����ű���ÿ��������
public class GhostEffectControler : MonoBehaviour
{
    [Tooltip("��Ҫ������ײ�����ǩ")]
    [SerializeField] private string playerTag = "Player";
    [Tooltip("��ͣ����ʱ�䣨�룩")]
    [SerializeField] private float pausedTime = 5f;

    private bool isPaused;

    private void Start()
    {
        isPaused = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("��ײ��⵽: " + collision.gameObject.name + ", ��ǩ: " + collision.gameObject.tag);
        HandleCollision(collision.gameObject);
    }
    private void HandleCollision(GameObject otherObject) 
    {
        // ����Ƿ��������ײ
        if (otherObject.CompareTag(playerTag)&&(!isPaused))
        {
            Debug.Log("��⵽��ײ��ң�ִ����ͣ��");
            PausedGhost();
        }
    }
    //��ͣ���˶���
    private IEnumerator PausedGhost() 
    { 
        //��ͣ
        isPaused=true;
        GetComponent<Collider>().enabled=false;
        //�ȴ���ͣʱ��
        yield return new WaitForSeconds(pausedTime);
        //����
        isPaused=false;
        GetComponentInChildren<Collider>().enabled=true;
    }
}
