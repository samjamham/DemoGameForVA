using UnityEngine;

public class NPC_Telepath : NPCBase
{
    void Start()
    {
        Setup();

        setUpDialogBox();
        Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
    }
    public override void interact()
    {
        return;

    }
}
