using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleAudioManager : MonoBehaviour
{
    // ����ʵ��
    public static SimpleAudioManager Instance { get; private set; }

    [Header("��������")]
    [SerializeField] private AudioClip menuBGM; // ���ڲ˵�������ǰ�ó�����BGM
    [SerializeField] private AudioClip gameBGM; // ������Ϸ������BGM
    [SerializeField] private string gameSceneName = "Demo_01"; // ��Ϸ����������

    [Header("��������")]
    [Range(0f, 1f)]
    [SerializeField] private float musicVolume = 0.7f;

    [Header("���뵭��")]
    [SerializeField] private float fadeTime = 1.0f; // ���뵭��ʱ��

    // ���
    private AudioSource audioSource;
    private bool isFading = false;

    private void Awake()
    {
        // ����ģʽ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // �����ƵԴ
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.volume = musicVolume;

            // ��ʼ���Ų˵�BGM
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
        // ע�᳡�������¼�
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // ȡ��ע�᳡�������¼�
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // ��������ʱ�л�����
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ����Ƿ���Ҫ����BGM
        if (scene.name == gameSceneName)
        {
            ChangeBGM(gameBGM);
        }
        else if (audioSource.clip != menuBGM)
        {
            ChangeBGM(menuBGM);
        }
    }

    // �л�BGM
    public void ChangeBGM(AudioClip newBGM)
    {
        if (audioSource.clip == newBGM || newBGM == null) return;

        if (isFading) return; // ����Ѿ��ڵ��뵭���������

        // ���뵭���л�BGM
        StartCoroutine(FadeBGM(newBGM));
    }

    // ���뵭��Э��
    private System.Collections.IEnumerator FadeBGM(AudioClip newBGM)
    {
        isFading = true;

        // ���浱ǰ����
        float startVolume = audioSource.volume;

        // ����
        float timer = 0;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, timer / fadeTime);
            yield return null;
        }

        // �л�BGM
        audioSource.clip = newBGM;
        audioSource.Play();

        // ����
        timer = 0;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, musicVolume, timer / fadeTime);
            yield return null;
        }

        // ȷ��������ȷ
        audioSource.volume = musicVolume;

        isFading = false;
    }

    // �ֶ��л�����ϷBGM
    public void PlayGameBGM()
    {
        ChangeBGM(gameBGM);
    }

    // �ֶ��л����˵�BGM
    public void PlayMenuBGM()
    {
        ChangeBGM(menuBGM);
    }

    // ��������
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        audioSource.volume = musicVolume;
    }

    // ֹͣ��������
    public void StopMusic()
    {
        audioSource.Stop();
    }
}