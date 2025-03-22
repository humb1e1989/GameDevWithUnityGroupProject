using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // 定义所有场景名称，使用完整的路径
    public enum SceneType
    {
        Start = 0,
        Introduction = 1,
        Rule1 = 2,
        Rule2 = 3,
        Rule3 = 4,
        ready = 5,
        Game = 6
    }

    // 加载场景的通用方法
    public void LoadScene(SceneType sceneType)
    {
        // 使用完整路径来加载场景
        string sceneName = GetSceneName(sceneType);
        SceneManager.LoadScene(sceneName); // 加载场景
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
            case SceneType.ready:
                return "Start scenes/ready";
            case SceneType.Game:
                return "PolygonHorrorMansion/Scenes/Demo_01";
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

    public void GoToready()
    {
        LoadScene(SceneType.ready); // 从规则3界面跳转到规则4界面
    }

    public void StartGame()
    {
        LoadScene(SceneType.Game); // 从规则4界面跳转到游戏开始界面
    }
}
