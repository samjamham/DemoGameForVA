using UnityEngine;

namespace dialoguetree
{
    [System.Serializable]
    public struct Choises
    {
        public string Response;
        public int NextLineID;
    }
    [System.Serializable]
    public struct DialogueTree
    {
        public string Line;
        public bool Terminator;
        public Choises[] Choises;
        //public string[] Choises;
        //public int[] NextLines;
    }
}
