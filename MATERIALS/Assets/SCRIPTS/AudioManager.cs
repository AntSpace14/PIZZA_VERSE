using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [System.Serializable]
    public class SceneAudio
    {
        public string sceneName;
        public AudioClip audioClip;
        public bool loop;
    }

    public SceneAudio[] sceneAudioClips;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false; // Ensure looping is disabled initially
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (SceneAudio sceneAudio in sceneAudioClips)
        {
            if (sceneAudio.sceneName == scene.name)
            {
                audioSource.clip = sceneAudio.audioClip;
                audioSource.loop = sceneAudio.loop;
                audioSource.Play();
                return;
            }
        }
    }
}
