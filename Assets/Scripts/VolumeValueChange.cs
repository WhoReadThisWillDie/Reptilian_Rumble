using UnityEngine;
using UnityEngine.UI;

public class VolumeValueChange : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource not assigned to VolumeControl script!");
            return;
        }

        if (volumeSlider != null)
        {
            // Set the slider value based on the initial volume
            volumeSlider.value = audioSource.volume;
            // Subscribe to the slider's OnValueChanged event
            volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
        else
        {
            Debug.LogError("Slider not assigned to VolumeControl script!");
        }
    }

    void OnSliderValueChanged(float value)
    {
        // Update the audio source volume when the slider value changes
        audioSource.volume = value;
    }
}
