using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    private bool isFullScreen = true;

    public void ShowSettings()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    public void MusicVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", sliderValue);
    }
    public void EffectVolume(float sliderValue)
    {
        mixer.SetFloat("EffectVolume", sliderValue);
    }
}
