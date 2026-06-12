using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager Instance;
    public int[] AudioClipsHeard { get; private set; }


    private void Awake()
    {
        if(Instance== null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            AudioClipsHeard = new int[1] { 0 };
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddHeardClip(int IDin)
    {
        if (AudioClipsHeard.Contains(IDin))
            return;
        else
        {
            var list = new List<int>(AudioClipsHeard);
            list.Add(IDin);

            AudioClipsHeard = list.ToArray();
        }
    }
    public bool GetHeardClip(int IDin)
    {
        foreach (int myIDs in AudioClipsHeard)
        {
            if (IDin == myIDs)
                return true;
        }
        return false;
    }
}
