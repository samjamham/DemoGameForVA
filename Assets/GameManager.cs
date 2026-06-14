using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager Instance;
    public string[] AudioClipsHeard { get; private set; }


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
    public void AddHeardClip(string IDin)
    {
        if (AudioClipsHeard == null)
        {
            AudioClipsHeard = new string[1] { IDin };
        }
        if (AudioClipsHeard.Contains(IDin))
            return;
        else
        {
            var list = new List<string>(AudioClipsHeard);
            list.Add(IDin);

            AudioClipsHeard = list.ToArray();
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
