using UnityEngine;
using UnityEngine.UI;

public class Audio_controls : MonoBehaviour
{
    public Toggle AudioToggle;
    public Toggle navigationToggle;
    public Toggle TimerToggle;
    public AudioSource[] AudioSources;
    public GameObject NavigationScript;
    public GameObject Timer;
    void Start()
    {
        AudioSources = FindObjectsOfType<AudioSource>();
        bool isAudioPlaying = false;
        foreach (AudioSource audioSource in AudioSources)
        {
            if (audioSource.isPlaying)
            {
                isAudioPlaying = true;
                break;
            }
        }
        AudioToggle.isOn = isAudioPlaying;
        AudioToggle.onValueChanged.AddListener(OnToggleChangedAudio);
        navigationToggle.onValueChanged.AddListener(OnToggleChangedNavigate);
        TimerToggle.onValueChanged.AddListener(OnToggleChangedTimer);
    }

    private void OnToggleChangedAudio(bool isOn)
    {
        if (isOn)
        {
            foreach (AudioSource audioSource in AudioSources)
            {
                audioSource.Play();
            }
        }
        else
        {
            foreach (AudioSource audioSource in AudioSources)
            {
                audioSource.Stop();
            }
        }
    }

    private void OnToggleChangedNavigate(bool isOn)
    {
        if (isOn)
        {
            NavigationScript.SetActive(true);
        }
        else
        {
            NavigationScript.SetActive(false);
        }
    }


    private void OnToggleChangedTimer(bool isOn)
    {
        if (isOn)
        {
            Timer.SetActive(true);
        }
        else
        {
           Timer.SetActive(false);
        }
    }
}
