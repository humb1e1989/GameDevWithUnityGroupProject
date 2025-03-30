using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleAudioManager : MonoBehaviour
{
    // 单例实例
    public static SimpleAudioManager Instance { get; private set; }

    [Header("音乐设置")]
    [SerializeField] private AudioClip menuBGM; // 用于菜单和其他前置场景的BGM
    [SerializeField] private AudioClip gameBGM; // 用于游戏场景的BGM
    [SerializeField] private string gameSceneName = "Demo_01"; // 游戏场景的名称

    [Header("音量设置")]
    [Range(0f, 1f)]
    [SerializeField] private float musicVolume = 0.7f;

    [Header("淡入淡出")]
    [SerializeField] private float fadeTime = 1.0f; // 淡入淡出时间

    // 组件
    private AudioSource audioSource;
    private bool isFading = false;

    private void Awake()
    {
        // 单例模式
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 添加音频源
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.volume = musicVolume;

            // 初始播放菜单BGM
            audioSource.clip = menuBGM;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 注册场景加载事件
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // 取消注册场景加载事件
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 场景加载时切换音乐
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 检查是否需要更改BGM
        if (scene.name == gameSceneName)
        {
            ChangeBGM(gameBGM);
        }
        else if (audioSource.clip != menuBGM)
        {
            ChangeBGM(menuBGM);
        }
    }

    // 切换BGM
    public void ChangeBGM(AudioClip newBGM)
    {
        if (audioSource.clip == newBGM || newBGM == null) return;

        if (isFading) return; // 如果已经在淡入淡出，则忽略

        // 淡入淡出切换BGM
        StartCoroutine(FadeBGM(newBGM));
    }

    // 淡入淡出协程
    private System.Collections.IEnumerator FadeBGM(AudioClip newBGM)
    {
        isFading = true;

        // 保存当前音量
        float startVolume = audioSource.volume;

        // 淡出
        float timer = 0;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, timer / fadeTime);
            yield return null;
        }

        // 切换BGM
        audioSource.clip = newBGM;
        audioSource.Play();

        // 淡入
        timer = 0;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, musicVolume, timer / fadeTime);
            yield return null;
        }

        // 确保音量正确
        audioSource.volume = musicVolume;

        isFading = false;
    }

    // 手动切换到游戏BGM
    public void PlayGameBGM()
    {
        ChangeBGM(gameBGM);
    }

    // 手动切换到菜单BGM
    public void PlayMenuBGM()
    {
        ChangeBGM(menuBGM);
    }

    // 调整音量
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        audioSource.volume = musicVolume;
    }

    // 停止所有音乐
    public void StopMusic()
    {
        audioSource.Stop();
    }
}