using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;

    [Header("Music")]
    public AudioClip levelsMusic;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "StartScene":
                PlayMusic(null);
                break;
            case "Level01":
                PlayMusic(levelsMusic);
                break;
            case "Level02":
                PlayMusic(levelsMusic);
                break;
            case "CreditsScene":
                PlayMusic(null);
                break;
        }
    }

    void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip)
        {
            return;
        }

        audioSource.clip = clip;
        audioSource.Play();
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void GetVolume()
    {
        PlayerPrefs.GetFloat("MusicVolume", 1f);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
