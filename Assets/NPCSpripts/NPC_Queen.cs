using UnityEngine;

public class NPC_Queen: NPCBase
{
    void Start()
    {
        Setup();
    }
    public override void interact()
    {
        Dialogbox.GetComponent<Dialogue>().StartDialogue(0);
        return;
        
    }
}
