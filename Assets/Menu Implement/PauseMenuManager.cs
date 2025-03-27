using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [Header("暂停菜单UI")]
    [SerializeField] private GameObject pauseMenuPanel;

    [Header("帮助与指南UI")]
    [SerializeField] private GameObject helpGuidePanel;

    [Header("设置")]
    [SerializeField] private KeyCode pauseKey = KeyCode.P;
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    private bool isPaused = false;

    private void Start()
    {
        // 确保游戏开始时暂停菜单是隐藏的
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(false);

        if (helpGuidePanel != null)
            helpGuidePanel.SetActive(false);

        // 确保游戏开始时时间正常流动
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu)");
    }

    private void Update()
    {
        // 检测是否按下暂停键
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause();
        }
    }

    // 切换暂停状态 - 这个方法可以绑定到按钮
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ContinueGame();
        }
    }

    // 暂停游戏
    private void PauseGame()
    {
        // 显示暂停菜单
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(true);

        // 完全暂停游戏时间
        Time.timeScale = 0f;
    }

    // 继续游戏 - 公共方法可以直接绑定到Continue按钮
    public void ContinueGame()
    {
        // 隐藏暂停菜单和帮助面板
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(false);

        if (helpGuidePanel != null)
            helpGuidePanel.SetActive(false);

        // 恢复游戏时间
        Time.timeScale = 1f;

        isPaused = false;
    }

    // 重新开始游戏 - 公共方法可以直接绑定到Restart按钮
    public void RestartGame()
    {
        // 恢复游戏时间
        Time.timeScale = 1f;

        // 重新加载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 显示帮助与指南面板 - 公共方法可以直接绑定到Help & Guide按钮
    public void ShowHelpGuide()
    {
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(false);

        if (helpGuidePanel != null)
            helpGuidePanel.SetActive(true);
    }

    // 隐藏帮助与指南面板 - 公共方法可以直接绑定到帮助面板上的Back按钮
    public void HideHelpGuide()
    {
        if (helpGuidePanel != null)
            helpGuidePanel.SetActive(false);

        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(true);
    }

    // 退出到主菜单 - 公共方法可以直接绑定到Exit按钮
    public void ExitToMainMenu()
    {
        //// 恢复游戏时间
        //Time.timeScale = 1f;

        // 加载主菜单场景
        SceneManager.LoadScene("MainMenu");
    }

    // 确保如果场景被销毁时游戏时间恢复正常
    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }

    // 退出游戏 - 公共方法可以直接绑定到Exit按钮
    public void ExitGame()
    {
        //// 恢复游戏时间
        //Time.timeScale = 1f;

        // 退出游戏
#if UNITY_EDITOR
            // 在Unity编辑器中停止播放模式
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在构建的应用程序中完全退出
        Application.Quit();
#endif

        Debug.Log("退出游戏");
    }

    public void Test() {

        Debug.Log("11111111111");
    
    
    }
}