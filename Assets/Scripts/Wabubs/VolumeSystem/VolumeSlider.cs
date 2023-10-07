using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    public string MixerName;
    private Slider slider;

    private void Start() {
        slider = GetComponent<Slider>();
        slider.minValue = VolumeManager.instance.MinVolume;
        slider.maxValue = VolumeManager.instance.MaxVolume;
    }

    private void Update() {
        slider.value = VolumeManager.instance.FilteredMixerVolumes[MixerName].Val;
    }

}
