using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;  // 主菜单
    public GameObject helpPanel;  // 帮助面板
    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);  // 游戏开始时隐藏暂停菜单
        helpPanel.SetActive(false);  // 游戏开始时隐藏帮助面板
    }

    void Update()
    {
        // 按下P键切换菜单
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);  // 显示暂停菜单
        helpPanel.SetActive(false); // 隐藏帮助面板
        Time.timeScale = 0f; // 暂停游戏
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);  // 隐藏暂停菜单
        helpPanel.SetActive(false);  // 隐藏帮助面板
        Time.timeScale = 1f; // 继续游戏
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // 恢复游戏速度
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 重新加载当前场景
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit(); // 退出游戏
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 在编辑器中停止游戏
#endif
    }

    // 显示 Help 面板
    public void ShowHelp()
    {
        Debug.Log("调用showHelp");

        helpPanel.SetActive(true);  // 显示帮助面板
        Debug.Log("显示帮助面板");
    }

    // 返回到暂停菜单
    public void HideHelp()
    {
        Debug.Log("调用hideHelp");
        helpPanel.SetActive(false);  // 隐藏帮助面板
        Debug.Log("隐藏help");
    }
}
