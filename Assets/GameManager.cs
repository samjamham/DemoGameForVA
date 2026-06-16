using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager Instance;
    public string[] AudioClipsHeard { get; private set; }
    public string[] DialogueLineSeen { get; private set; }


    private void Awake()
    {
        if(Instance== null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddHeardClip(string IDin, string DialogueLine)
    {
        if (AudioClipsHeard == null)
        {
            AudioClipsHeard = new string[1] { IDin };
            DialogueLineSeen = new string[1] { DialogueLine };
        }
        if (AudioClipsHeard.Contains(IDin))
            return;
        else
        {
            //messy
            var list = new List<string>(AudioClipsHeard);
            list.Add(IDin);
            AudioClipsHeard = list.ToArray();

            var list2 = new List<string>(DialogueLineSeen);
            list2.Add(DialogueLine);
            DialogueLineSeen = list2.ToArray();
        }
    }
    public bool GetHeardClip(string IDin)
    {
        foreach (string myIDs in AudioClipsHeard)
        {
            if (IDin == myIDs)
                return true;
        }
        return false;
    }
}
