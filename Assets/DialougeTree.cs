using UnityEngine;

namespace dialoguetree
{
    [System.Serializable]
    public struct DialogueTree
    {
        public string Line;
        public bool Terminator;
        public string[] Choises;
        public int[] NextLines;
    }
}
