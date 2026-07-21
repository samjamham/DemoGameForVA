using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class NPC_KidN : NPCBase
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
        //16 -> Hungry //17 -> Nervous //18 -> Excited
        switch (CurrentIndex)
        {
            case 0:
                FindNPCByID(18).DialogueSwap(0);
                return true;
            case 1:
                FindNPCByID(18).DialogueSwap(1);
                return true;
            case 2:
                FindNPCByID(16).DialogueSwap(2);
                return true;
            case 3:
                //empty
                return false;
            case 4:
                FindNPCByID(18).DialogueSwap(4);
                return true;
            case 5:
                FindNPCByID(18).DialogueSwap(5);
                return true;
            case 6:
                FindNPCByID(16).DialogueSwap(6);
                return true;
            default:
                return false;
        }

        return false;
    }
}
