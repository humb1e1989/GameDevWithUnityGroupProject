using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public enum SceneType
    {
        Start = 0,
        Introduction = 1,
        Rule1 = 2,
        Rule2 = 3,
        Rule3 = 4,
        Rule4 = 5,
        ready = 6,
        Game = 7
    }

    public AudioClip buttonSound; // 直接拖拽音频文件到这里

    private SceneType targetSceneType; // 用于存储目标场景

    // 加载场景的通用方法
    public void LoadScene(SceneType sceneType)
    {
        PlayButtonSound(); // 立即播放按钮音效
        targetSceneType = sceneType; // 存储目标场景
        Invoke("DelayedLoadScene", 0.3f); // 0.5 秒后调用 DelayedLoadScene
    }

    // 延迟加载场景
    private void DelayedLoadScene()
    {
        SceneManager.LoadScene(GetSceneName(targetSceneType)); // 加载场景
    }

    // 播放按钮音效
    private void PlayButtonSound()
    {
        if (buttonSound != null)
        {
            // 直接播放音效，不依赖摄像机位置
            AudioSource.PlayClipAtPoint(buttonSound, Vector3.zero);
        }
        else
        {
            Debug.LogWarning("Button sound clip is not assigned!");
        }
    }

    // 根据枚举返回场景的完整路径
    private string GetSceneName(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.Start:
                return "Start scenes/start";
            case SceneType.Introduction:
                return "Start scenes/introduction";
            case SceneType.Rule1:
                return "Start scenes/rule1";
            case SceneType.Rule2:
                return "Start scenes/rule2";
            case SceneType.Rule3:
                return "Start scenes/rule3";
            case SceneType.Rule4:
                return "Start scenes/rule4";
            case SceneType.ready:
                return "Start scenes/ready";
            case SceneType.Game:
                return "Scenes/Demo_01";
            default:
                return string.Empty; // 默认返回空字符串
        }
    }

    // 你可以为每个场景切换定义具体的按钮方法（这些方法可以挂载到各个场景的按钮上）
    public void StartGameButton()
    {
        LoadScene(SceneType.Introduction); // 从开始界面跳转到介绍界面
    }

    public void GoToRule1()
    {
        LoadScene(SceneType.Rule1); // 从介绍界面跳转到规则1界面
    }

    public void GoToRule2()
    {
        LoadScene(SceneType.Rule2); // 从规则1界面跳转到规则2界面
    }

    public void GoToRule3()
    {
        LoadScene(SceneType.Rule3); // 从规则2界面跳转到规则3界面
    }

    public void GoToRule4()
    {
        LoadScene(SceneType.Rule4); // 从规则2界面跳转到规则3界面
    }

    public void GoToready()
    {
        LoadScene(SceneType.ready); // 从规则3界面跳转到规则4界面
    }

    public void StartGame()
    {
        LoadScene(SceneType.Game); // 从规则4界面跳转到游戏开始界面
    }
}