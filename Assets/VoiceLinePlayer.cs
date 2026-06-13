using UnityEngine;
using voicelinelist;

public class VoiceLinePlayer : MonoBehaviour
{
    [SerializeField] private VoiceLineList voiceLineList;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        voiceLineList.AllClips = Resources.LoadAll<AudioClip>("VoiceLines");
    }
    public void PlayClip(string ID)
    {
        foreach(AudioClip clip in voiceLineList.AllClips)
        {
            if(clip.name.Contains(ID))
            {
                audioSource.clip = clip;
                audioSource.Play();
            } 
        }
    }
    public void StopClip()
    {
        audioSource.Stop();
    }
}
