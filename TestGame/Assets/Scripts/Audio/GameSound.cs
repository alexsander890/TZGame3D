using UnityEngine;

public class GameSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip = new AudioClip[1];
    [SerializeField] int indexMusik = 0;
   
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        PlayMusic(indexMusik);
    }

    private void PlayMusic(int val)
    {
        audioSource.clip = audioClip[val];
        audioSource.Play();
    }


    public void SetVolumeMusic(float val)
    {
        audioSource.volume = val;
    }
}
