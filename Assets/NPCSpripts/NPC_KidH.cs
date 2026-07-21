using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class NPC_KidH : NPCBase
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
                FindNPCByID(17).DialogueSwap(0);
                return true;
            case 1:
                FindNPCByID(17).DialogueSwap(1);
                return true;
            case 2:
                FindNPCByID(18).DialogueSwap(2);
                return true;
            case 3:
                FindNPCByID(17).DialogueSwap(3);
                return true;
            case 4:
                //empty
                return false;
            case 5:
                FindNPCByID(17).DialogueSwap(5);
                return true;
            case 6:
                //empty
                return false;
            default:
                return false;
        }

        return false;
    }
}
