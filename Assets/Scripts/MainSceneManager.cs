using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{

    [SerializeField] private string gameSceneName = ""; // 游戏场景的名称，可在Inspector中修改

    void Update()
    {
        // 检测是否按下ESC键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    // 点击按钮时调用的方法
    public void StartGame()
    {
        Debug.Log("开始游戏 - 加载场景: " + gameSceneName);
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
