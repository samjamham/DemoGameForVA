using UnityEngine;

public class ReplayVoiceLines : MonoBehaviour
{
    [SerializeField] private GameObject UIelement;
    [SerializeField] private VoiceLinePlayer VLPlayer;

    public void toggleUIState()
    {
        if (UIelement.activeInHierarchy) 
        {
            VLPlayer.StopClip();
        }
        UIelement.SetActive(!UIelement.activeInHierarchy);
    }
}
