using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class NPC_Guard: NPCBase
{
    void Start()
    {
        Setup();
    }
    public override void interact()
    {
        setUpDialogBox();
        Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
        return;
    }

    public override bool SwapChecker(int CurrentIndex)
    {
        if (CurrentIndex == 12)
        {
            FindNPCByID(10).DialogueSwap(0);
            return true;
        }
        return false; 
    }
}
