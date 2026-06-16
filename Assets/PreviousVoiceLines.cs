using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreviousVoiceLines : MonoBehaviour
{
    [SerializeField] private GameObject ContentPrefab;
    [SerializeField] private GameObject SelectionLayout;
    [SerializeField] private GameManager GameManager;
    [SerializeField] private VoiceLinePlayer VLPlayer;

    private void OnEnable()
    {
        if(GameManager.AudioClipsHeard == null)
        {
            return;
        }
        int i = 0;
        foreach (string clips in GameManager.AudioClipsHeard)
        {
            GameObject ContentItem = GameObject.Instantiate(ContentPrefab, SelectionLayout.transform);
            ContentItem.GetComponentInChildren<TMP_Text>().text = GameManager.DialogueLineSeen[i];
            ContentItem.GetComponentInChildren<Button>().onClick.AddListener(() => VLPlayer.StopClip());
            ContentItem.GetComponentInChildren<Button>().onClick.AddListener(() => VLPlayer.PlayClip(clips));
            i++;
        }
    }
    private void OnDisable()
    {
        foreach (Transform child in SelectionLayout.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
