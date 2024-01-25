using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VolumeControl : MonoBehaviour
{
    public List<Transform> musicGroups; // Drag the parent objects of the music sources here in the Inspector
    public Transform soundEffectsGroup; // Drag the parent object of the sound sources here in the Inspector
    public Slider musicSlider;
    public Slider soundsSlider;

    private List<List<AudioSource>> musicSources = new List<List<AudioSource>>();
    private List<AudioSource> soundEffectsSources = new List<AudioSource>();

    void Start()
    {
        if (musicGroups == null || musicSlider == null || musicGroups.Count == 0)
        {
            Debug.LogError("Music Groups or Music Slider not correctly assigned to the script!");
            return;
        }

        if (soundEffectsGroup == null || soundsSlider == null)
        {
            Debug.LogError("Sounds Group or Sounds Slider not correctly assigned to the script!");
            return;
        }

        // Initialize musicSources list
        foreach (var group in musicGroups)
        {
            List<AudioSource> groupAudioSources = new List<AudioSource>();
            groupAudioSources.AddRange(group.GetComponentsInChildren<AudioSource>());
            musicSources.Add(groupAudioSources);
        }

        // Initialize soundEffectsSources list
        soundEffectsSources.AddRange(soundEffectsGroup.GetComponentsInChildren<AudioSource>());

        if (musicSlider != null)
        {
            musicSlider.value = GetAverageVolumeAcrossGroups(musicSources);
            musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        }

        if (soundsSlider != null)
        {
            soundsSlider.value = GetAverageVolume(soundEffectsSources);
            soundsSlider.onValueChanged.AddListener(OnSoundsSliderValueChanged);
        }
    }

    void OnMusicSliderValueChanged(float value)
    {
        SetVolumesAcrossGroups(musicSources, value);
    }

    void OnSoundsSliderValueChanged(float value)
    {
        SetVolumes(soundEffectsSources, value);
    }

    void SetVolumesAcrossGroups(List<List<AudioSource>> audioSourcesGroups, float volume)
    {
        foreach (var group in audioSourcesGroups)
        {
            foreach (var source in group)
            {
                source.volume = volume;
            }
        }
    }

    void SetVolumes(List<AudioSource> audioSources, float volume)
    {
        foreach (var source in audioSources)
        {
            source.volume = volume;
        }
    }

    float GetAverageVolume(List<AudioSource> audioSources)
    {
        float totalVolume = 0f;

        foreach (var source in audioSources)
        {
            totalVolume += source.volume;
        }

        return audioSources.Count > 0 ? totalVolume / audioSources.Count : 0f;
    }

    float GetAverageVolumeAcrossGroups(List<List<AudioSource>> audioSourcesGroups)
    {
        float totalVolume = 0f;
        int totalAudioSources = 0;

        foreach (var group in audioSourcesGroups)
        {
            totalAudioSources += group.Count;

            foreach (var source in group)
            {
                totalVolume += source.volume;
            }
        }

        return totalAudioSources > 0 ? totalVolume / totalAudioSources : 0f;
    }
}
