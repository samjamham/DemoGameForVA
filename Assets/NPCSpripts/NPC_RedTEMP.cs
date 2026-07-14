using UnityEngine;

public class NPC_Red : NPCBase
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

    public override bool SwapChecker(int index, int choise)
    {
        if (index == 1)
        {
            if (choise == 1)
            {
                FindNPCByID(22).DialogueSwap(0);
                return true;
            }
            if (choise == 2)
            {
                FindNPCByID(23).DialogueSwap(0);
                return true;
            }
        }
        return false;
    }
}
