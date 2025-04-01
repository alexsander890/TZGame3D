using UnityEngine;
using UnityEngine.UI;

public class SoundStatus : MonoBehaviour
{
    [SerializeField] GameSound gameMusic;  
    [SerializeField] SaveLoad sv;
    [SerializeField] Slider sliderVolumeMusic;
    [SerializeField] float volumeMusic;


    private void OnEnable()
    {
        SaveLoad.loadComplete += LoadVolumes; 
    }

    private void OnDisable()
    {
        SaveLoad.loadComplete -= LoadVolumes;
    }


    public void ChangeVolumeMusic()
    {
        gameMusic.SetVolumeMusic(sliderVolumeMusic.value);
        sv.SaveFloat("playerMusicVolume", sliderVolumeMusic.value);    
    }

   
    private void LoadVolumes()
    {
        volumeMusic = sv.LoadFloat("playerMusicVolume");    
        gameMusic.SetVolumeMusic(volumeMusic);    
        sliderVolumeMusic.value = volumeMusic;    
    }
}
