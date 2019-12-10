using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
    private static SFXManager instance;
    public static SFXManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                return FindObjectOfType<SFXManager>();
            }

            return instance;
        }
    }

    public AudioSource SFXAudioSource { get; set; }

    [SerializeField]
    private AudioMixer audioMixerMusic;

    [SerializeField]
    private AudioMixer audioMixerSFX;

    public SFXGroup sfxGroup;


    private void Awake()
    {
        SFXAudioSource = GetComponent<AudioSource>();
    }

    public void SetMusicVolume(Slider volume)
    {
        audioMixerMusic.SetFloat("Music", Mathf.Log10(volume.value) * 20);
    }

    public void SetSFXVolume(Slider volume)
    {
        audioMixerSFX.SetFloat("SFX", Mathf.Log10(volume.value) * 20);
    }

    public void PlaySound(string clip)
    {
        if (sfxGroup == null)
        {
            return;
        }

        var audioClip = sfxGroup.GetClip(clip);

        if (audioClip == null)
        {
            return;
        }

        SFXAudioSource.PlayOneShot(audioClip);
    }

    public void PlayAudioClip(AudioClip audioClip, bool loop)
    {
        if (audioClip != null)
        {
            SFXAudioSource.clip = audioClip;
            SFXAudioSource.loop = loop;
            SFXAudioSource.Play();
        }
    }

    public void StopAudioClip()
    {
        SFXAudioSource.Stop();
        SFXAudioSource.clip = null;
        SFXAudioSource.loop = false;
    }
}