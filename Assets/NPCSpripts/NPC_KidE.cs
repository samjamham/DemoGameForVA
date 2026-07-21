using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class NPC_KidE : NPCBase
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
                FindNPCByID(16).DialogueSwap(1);
                return true;
            case 1:
                FindNPCByID(17).DialogueSwap(2);
                return true;
            case 2:
                //empty 
                return false;
            case 3:
                FindNPCByID(16).DialogueSwap(3);
                return true;
            case 4:
                FindNPCByID(16).DialogueSwap(4);
                return true;
            case 5:
                //empty 
                return false;
            case 6:
                FindNPCByID(17).DialogueSwap(6);
                return true;
            default:
                return false;
        }

        return false;
    }
}
