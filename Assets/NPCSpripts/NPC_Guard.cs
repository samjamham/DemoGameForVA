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
}
