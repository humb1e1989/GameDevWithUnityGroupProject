using System.Collections;
using UnityEngine;
//����ű���ÿ��������
public class GhostEffectControler : MonoBehaviour
{
    [Tooltip("��Ҫ������ײ�����ǩ")]
    [SerializeField] private string playerTag = "Player";
    [Tooltip("��ͣ����ʱ�䣨�룩")]
    [SerializeField] private float pausedTime = 5f;

    [SerializeField] private bool isPaused=false;

    private void Start()
    {

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
            //��ͣ
            isPaused = true;
            GetComponent<Collider>().enabled = false;
            //�ȴ���ͣʱ��
            yield return new WaitForSeconds(pausedTime);
            //����
            isPaused = false;
            GetComponentInChildren<Collider>().enabled = true;
            Debug.Log(gameObject.name+" ������ͣ��");
        }
    }
}
