using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;  // 赋值 UI 菜单
    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false); // 游戏开始时隐藏菜单
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // 暂停游戏
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
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
}
