using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{

    [SerializeField] private string gameSceneName = ""; // ��Ϸ���������ƣ�����Inspector���޸�

    void Update()
    {
        // ����Ƿ���ESC��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    // �����ťʱ���õķ���
    public void StartGame()
    {
        Debug.Log("��ʼ��Ϸ - ���س���: " + gameSceneName);
        SceneManager.LoadScene(gameSceneName);
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
