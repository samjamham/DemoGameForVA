using UnityEngine;

public class ReplayVoiceLines : MonoBehaviour
{
    [SerializeField] private GameObject UIelement;

    public void toggleUIState()
    {
        UIelement.SetActive(!UIelement.activeInHierarchy);
    }
}
