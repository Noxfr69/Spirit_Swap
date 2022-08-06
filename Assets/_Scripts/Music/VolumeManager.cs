using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class VolumeManager : MonoBehaviour
{
    public AudioMixer MusicMaster;
    public AudioMixer SFXMaster;


    public void SetLevelMusic(float sliderMMusicValue){
        MusicMaster.SetFloat("MusicVolume", Mathf.Log10(sliderMMusicValue)*20 );
    }

    
    public void SetLevelSFX(float sliderSFXValue){
        SFXMaster.SetFloat("SfxVolume", Mathf.Log10(sliderSFXValue)*20 );
    }


}
